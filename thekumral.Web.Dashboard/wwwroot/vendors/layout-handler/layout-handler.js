var isFluid = JSON.parse(localStorage.getItem('isFluid'));
if (isFluid) {
    var container = document.querySelector('[data-layout]');
    container.classList.remove('container');
    container.classList.add('container-fluid');
}