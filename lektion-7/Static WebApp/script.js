function getProducts(id) {
    fetch('https://localhost:7084/api/Products')
    .then(res =>  res.json())
    .then(data => {
        
        for(let item of data) {
            document.getElementById(id).innerHTML += 
            `<div class="col">
                <div class="card h-100 shadow">
                <div class="card-body">
                    <h5 class="card-title">${item.name}</h5>
                    <p class="card-text">
                        ${item.description}
                    </p>
                </div>
                <div class="card-footer">
                    <small class="text-muted">Pris ${item.price}:-</small>
                </div>
            </div>
            </div>
            `
        }
    })
}


function postProduct(event) {
    event.preventDefault()

    let product = {
        name : event.target['name'].value,
        price : event.target['price'].value,
        description : event.target['description'].value
    }

    fetch('https://localhost:7084/api/products', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(product)
    })
    .then(() => {
        location.href = 'get-example.html';
    })    
}




// document.getElementById('theForm').addEventListener('submit', function(event) {
//     event.preventDefault()

//     let product = {
//         name : event.target['name'].value,
//         price : event.target['price'].value,
//         categoryName : event.target['categoryName'].value
//     }

//     fetch('https://localhost:7084/api/products', {
//         method: 'post',
//         headers: {
//             'Content-Type': 'application/json'
//         },
//         body: JSON.stringify(product)
//     })
// })
