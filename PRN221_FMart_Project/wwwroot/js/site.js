$('.toggle').on('click', function () {
    $('.sidebar').toggleClass('close');
});

let arrows = document.querySelectorAll('.arrow');
for (var i = 0; i < arrows.length; i++) {
    arrows[i].addEventListener("click", (e) => {
        let arrowParrent = e.target.parentElement.parentElement;
        arrowParrent.classList.toggle("show");
    })
}