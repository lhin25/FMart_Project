const { signalR } = require("../microsoft/signalr/dist/browser/signalr")

$(() => {
    LoadCustomerData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.Start();

    connection.on("LoadCustomer", function () {
        LoadCustomerData();
    })


    function LoadCustomerData() {
        var content = '';
        $.ajax({
            url: '/Areas/Staff/Sale?handler=GetCustomer',
            type: 'GET',
            success: (result) => {
                alert("yes");
                console.log(result);
                content += `<div class="customer-info">
                                    <p class="customer-full-name">${result[result.length - 1].FullName}</p>
                                    <p>
                                        <span class="customer-phone">${result[result.length - 1].PhoneNumber} </span> |
                                        <span class="customer-point">${result[result.length - 1].Points} points</span>
                                    </p>
                                </div>
                                <a class="customer-remove"><i class='bx bx-x'></i></a>
                `;
                $("#customerInfo").html(content); 
            },
            error: (error) => {
                console.log(error)
            }
        });
    }
})