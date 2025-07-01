document.addEventListener('DOMContentLoaded', function () {
    var expandButton = document.getElementById('expand-button');
    var description = document.querySelector('.description');

    if (expandButton && description) {
        expandButton.addEventListener('click', function (event) {
            event.preventDefault();
            if (description.style.display === 'none') {
                description.style.display = 'block';
                this.innerText = 'Mostrar menos';
            } else {
                description.style.display = 'none';
                this.innerText = 'Mostrar más';
            }
        });
    }
});