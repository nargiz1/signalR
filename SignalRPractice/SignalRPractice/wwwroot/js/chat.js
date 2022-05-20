"use strict"
$(function() {
    window.scrollTo(0, document.body.scrollHeight);
    var connection = new signalR.HubConnectionBuilder().withUrl("/messages", {
        accessTokenFactory: () => "testing"
    }).build();

    document.getElementById("sendButton").disabled = true;

    connection.on("ReceiveMessage", function (message) {
        var message = `
        <div class="chat-item">
            <p class="name">smth</p>
            <p class="text">`+message+`</p>
            <div class="text-end">
                <span class="time">smth</span>
            </div>
        </div>`;
        $("#chat-wrapper").append(message);
        console.log(message);
        window.scrollTo(0, document.body.scrollHeight);
    });

    connection.on("UserConnected", function (connectionId) {
        var groupElement = document.getElementById("groupSelector");
        var option = document.createElement("option");
        option.text = connectionId;
        option.value = connectionId;
        groupElement.add(option);
    })

    connection.on("UserDisconnected", function (connectionId) {
        var groupElement = document.getElementById("groupSelector");
        for (var i = 0; i < groupElement.lenght; i++) {
            if (groupElement.options[i].value == connectionId) {
                groupElement.remove(i);
            }
        }
    })
    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        Send();
        event.preventDefault();

    });
    $(document).on("keyup", "#messageInput", function (e) {
        if (e.keyCode == 13) {
            Send();
        }
    })
    $(document).on("click", "#joinGroup", function (event) {
        connection.invoke("JoinGroup", "privateGroup");
        event.preventDefault();
    })
    function Send() {
        var message = document.getElementById("messageInput").value;
        var groupElement = document.getElementById("groupSelector");
        var groupValue = groupElement.options[groupElement.selectedIndex].value;
        if (groupValue == "all" || groupValue == "myself") {
            var method = groupValue == "all" ? "SendMessageToAll" : "SendMessageToCaller";
            connection.invoke(method, message);
        }
        else if (groupValue == "privateGroup") {
            connection.invoke("SendMessageToGroup", groupValue, message);
        }
        else {
            connection.invoke("SendMessageToUser", groupValue, message);
        }
        $("#messageInput").val('');
    }
})