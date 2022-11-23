let messages = document.getElementsByClassName('message')
for (let i = 0; i < messages.length; i++) {
    messages[i].addEventListener("click", function (e){
        e.preventDefault();
        showMessage(messages[i])
    })
}

function showMessage(element){
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