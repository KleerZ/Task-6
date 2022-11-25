const hub =  new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

window.onload = async () => {
    await hub.start()
}

function showMessage(element) {
    let title = element.getElementsByClassName('message-title')[0].innerHTML;
    let sender = element.getElementsByClassName('message-sender')[0].innerHTML;
    let date = element.getElementsByClassName('message-date')[0].innerHTML;
    let body = element.getElementsByClassName('message-body')[0].innerHTML;

    let modalTitle = document.getElementById('modal-title')
    let modalSender = document.getElementById('modal-sender')
    let modalDate = document.getElementById('modal-date')
    let modalBody = document.getElementById('modal-body')

    modalTitle.innerHTML = title
    modalSender.innerHTML = sender
    modalDate.innerHTML = date
    modalBody.innerHTML = body
}

async function getUserNames() {
    let response = await fetch("Message/GetUserNames/", {
        method: 'POST',
        body: JSON.stringify(),
        headers: {
            "Content-Type": "application/json"
        }
    })

    return response.json()
}

let sendBtn = document.getElementById('send-btn')
sendBtn.addEventListener("click", async () => {
    let recipient = document.getElementsByClassName("recipient-input")[0];
    let title = document.getElementById("send-title");
    let body = document.getElementsByClassName("send-body")[0];
    let sender = document.getElementById("current-user");

    if (recipient.value !== "" && title.value !== "" && body.value !== ""){
        hub.invoke("Send", sender.value, body.value, recipient.value, title.value)
            .catch(function (exception) {
                showError("The user is not exists")
            });

        clearAllFields()
    }
    else{
        showError("Fill in all the fields")
    }
})

function clearAllFields(){
    let recipient = document.getElementsByClassName("recipient-input")[0];
    let title = document.getElementById("send-title");
    let body = document.getElementsByClassName("send-body")[0];

    recipient.value = ""
    title.value = ""
    body.value = ""
}

hub.on('Send', function (message) {
    addMessageToList(message)
});

function showError(message){
    let errorContainer = document.querySelector(".error-container")
    
    let html = `
        <div class="alert alert-danger alert-dismissible" role="alert">
            <div>${message}</div>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    `
    
    errorContainer.innerHTML += html
}