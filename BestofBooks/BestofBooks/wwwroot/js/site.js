// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.querySelectorAll('.navLink').forEach
    (link => {
        if (link.href === window.location.href) {
            link.setAttribute('aria-current', 'page')
        }
    })