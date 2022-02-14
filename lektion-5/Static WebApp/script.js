fetch('https://localhost:7224/api/Services')
.then(res => res.json())
.then(data => {
    for(let item of data) {
        document.getElementById('service-items').innerHTML += `                    
        <div class="col">
        <div class="card h-100 shadow">           
            <div class="d-flex justify-content-center my-4">
                <div class="circle">
                    <i class="${item.icon}"></i>
                </div>   
            </div>
            <div class="card-body text-center">
                <h5 class="card-title">${item.title}</h5>
                <p class="card-text">${item.description}</p>
            </div>
        </div>
    </div>`
    }
})



// js =                             =       fetch('').then(res => res.json()).then(data => {})
// react, vue, svelte, angular      =       fetch('').then(res => res.json()).then(data => {})
//                                          const data = axios.get('')
// ASP.NET                          =       using (var client = new HttpClient) {  var result = await client.Content }