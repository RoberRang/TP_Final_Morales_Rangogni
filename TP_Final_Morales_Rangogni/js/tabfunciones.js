tabBars = document.querySelectorAll(".tab-bar a")
contents = document.querySelectorAll(".content")

resetTabs()
contents[0].style = `display: block;`
tabBars[0].style = `background-color: var(--tab-body-color); color: var(--font-color-dark)`

tabBars.forEach(function (tabBar, tabBarIndex) {
    tabBar.addEventListener("click", function () {
        resetTabs()
        contents[tabBarIndex].style = `display: block; background-color: var(--tab-body-color); color: var(--font-color-dark);`
        this.style = `background-color: var(--tab-body-color); color: var(--font-color-dark); transition: all .5s`
    })
})

function resetTabs() {
    for (let i = 0; i < contents.length; i++) {
        contents[i].style = `display: none; background-color: var(--tab-body-color); color: var(--tab-text-color-light);`
        tabBars[i].style = `background-color: var(--tab-background-color); color: var(--tab-text-color-light); transition: all .5s`
    }
}

function checkTab(e) {
    if (e.keyCode === 9) {
        for (let i = 0; i < tabBars.length; i++) {
            tabBars[i].classList.add('show-outline')
        }
        window.removeEventListener('keydown', checkTab);
    }
}
window.addEventListener('keydown', checkTab);