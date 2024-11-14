$('.toggle').on('click', function () {
    $('.sidebar').toggleClass('close');
});

let arrows = document.querySelectorAll('.arrow');
for (var i = 0; i < arrows.length; i++) {
    arrows[i].addEventListener("click", (e) => {
        let arrowParrent = e.target.parentElement.parentElement;
        arrowParrent.classList.toggle("show");
    })
};

$('#newCustomerBtn').on('click', function () {
    addCustomer('AddNewCustomer');
});

function addCustomer(actionType) {
    const fullname = $('#fullName').val();
    const phonee = $('#phoneNumber').val();

    $.ajax({
        type: 'POST',
        url: '/Areas/Staff/Sale?handler=' + actionType, // Replace with your actual page model URL
        data: {
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(),
            name: fullname,
            phone: phonee
        },
        success: function (response) {
            if (typeof response !== 'object') {
                response = JSON.parse(response); // Try to parse if not already an object
            }
            alert(response.message);

            // Optionally close the modal
            $('#newCustomerModal').modal('hide');
            $('')
        },
        error: function (xhr, status, error) {
            // Handle error
            console.error(error);
            alert('Something went wrong. Please try again.');
        }
    });
}

function formatCurrency(money) {
    return money.toLocaleString('vi-VN', {
        style: 'decimal',
        minimumFractionDigits: 0,
        maximumFractionDigits: 0
    });
}