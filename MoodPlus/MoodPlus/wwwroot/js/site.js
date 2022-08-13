// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const btn = document.getElementById('policy-btn');

btn.addEventListener('click', () => {
    var pol = document.getElementById('policy-body');
    if (pol.style.display === 'none') {
        pol.style.display = 'none';
    } else {
        pol.style.display = 'block';
    }
});