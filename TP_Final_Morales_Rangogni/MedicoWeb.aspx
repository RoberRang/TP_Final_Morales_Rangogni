<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MedicoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.MedicoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentLogin" runat="server">
         <section>
			<div class="tab-bar">
				<a href="#fruit">AGENDA</i></span></a>
				<a href="#fruit">PACIENTES</a>
				<a href="#fruit">TURNOS</a>
			</div>
			<div class="content">
				<h2>AGENDA<span><i class="fas fa-apple-alt"></i></span></h2>
				<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste omnis aliquid ad, ex quisquam, odio vero ipsam quo totam soluta eos repellendus, rerum vel nihil nisi cum numquam, consectetur. Sequi nemo, a. Ad perferendis nostrum explicabo quas tempora esse quae quam atque officia neque, mollitia earum blanditiis alias aperiam molestiae.</p></div>
			<div class="content">
				<h2>PACIENTES <span><i class="fas fa-times"></i></span></h2>
				<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste omnis aliquid ad, ex quisquam, odio vero ipsam quo totam soluta eos repellendus, rerum vel nihil nisi cum numquam, consectetur.</p></div>
			<div class="content">
				<h2>Vegetables <span><i class="fas fa-carrot"></i></span></h2>
				<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste omnis aliquid ad, ex quisquam, odio vero ipsam quo totam soluta eos repellendus, rerum vel nihil nisi cum numquam, consectetur. Sequi nemo, a. Ad perferendis nostrum explicabo quas tempora esse quae quam atque officia neque, mollitia earum blanditiis alias aperiam molestiae. Sequi nemo, a. Ad perferendis nostrum explicabo quas tempora esse quae quam atque officia neque, mollitia earum blanditiis alias aperiam molestiae.</p></div>
		</section>

	
    
   
    <script>
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
    </script>
</asp:Content>
