function sendCreateUser(payload){
    fetch("http://localhost:5115/api/storeOnline/users/create", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    })
        .then((response) => response.status === 200
            ? console.log("User successfully created")
            : console.error(`Request returned failed status code = ${response.status}, error text: ${response.statusText}`), 
        rsl =>console.error(`Rejected`))
        .catch(error => {
            console.log(`Unable to send a request. Error: ${error}`)
        });
}

function sendGetUserById(comment, id){
    fetch(`http://localhost:5115/api/storeOnline/users/${id}/User`)
    .then(async response => {
        let message = "";
        if (response.status === 200) {
            message = JSON.stringify(await response.json());
        }
        else if (response.status === 204) {
            message = "User not found";
        }
        else {
            console.error(`Error ${response.status}: ${response.statusText}`);
        }
        comment.innerText = "";
        comment.innerText = message;
    });
}

function checkSum(a, b, sum, onFf, onRj){
    if(a+b === sum){
        onFf();
    }
    else {
        onRj();
    }
}