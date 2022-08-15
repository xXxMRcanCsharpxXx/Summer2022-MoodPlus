// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const btn = document.getElementById('policy-btn');
let pol = document.getElementById('policy-body');
pol.style.display = 'none';

btn.addEventListener('click', () => {
    if (pol.style.display === 'flex') {
        pol.style.display = 'none';
    } else {
        pol.style.display = 'flex';
    }
});