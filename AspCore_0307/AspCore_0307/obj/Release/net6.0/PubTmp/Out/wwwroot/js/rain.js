document.addEventListener("DOMContentLoaded", function () {
    const rainContainer = document.querySelector(".rain");

    function createRain() {
        for (let i = 0; i < 100; i++) {
            const drop = document.createElement("div");
            drop.classList.add("drop");
            drop.style.left = `${Math.random() * 100}%`;
            drop.style.animationDelay = `${Math.random() * 2}s`;
            rainContainer.appendChild(drop);
        }
    }

    createRain();
});