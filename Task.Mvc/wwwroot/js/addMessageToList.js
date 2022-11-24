function addMessageToList(message) {
    let messageContainer = document.querySelector('.message-container')

    let date = new Date(message.date);
    let dateSend = `${date.getMonth() + 1}.${date.getDate()}.${date.getFullYear()} ${date.getHours()}:${date.getMinutes()}`;
    
    let messageHtml = `
        <div class="col message new-message" onclick="showMessage(this);removeMessageHighlight(this)" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
            <div class="row message-title">Title: ${message.title}</div>
            <div class="row message-sender">Sender: ${message.sender}</div>
            <div class="row message-date">Date: ${dateSend}</div>
            <div class="row message-body">
                ${message.body}
            </div>
        </div>
    `;
    
    let allMessages = messageContainer.innerHTML
    messageContainer.innerHTML = ""
    messageContainer.innerHTML += messageHtml
    messageContainer.innerHTML += allMessages
}

function removeMessageHighlight(element){
    element.classList.remove("new-message")
}