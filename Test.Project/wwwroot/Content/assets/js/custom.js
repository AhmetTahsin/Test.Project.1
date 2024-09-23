var swiper = new Swiper(".mySwiper", {

    slidesPerGroup: 1,
    loop: true,
    loopFillGroupWithBlank: true,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },

    breakpoints: {
        1920: {
            slidesPerView: 8,
            spaceBetween: 30
        },
        1028: {
            slidesPerView: 6,
            spaceBetween: 30
        },
        768: {
            slidesPerView: 3,
            spaceBetween: 30
        },
        480: {
            slidesPerView: 1,
            spaceBetween: 10
        }

    }
});


$('.phone-mask').inputmask({
    mask: ['9(999) 999-9999'],
    //jitMasking: 3,
    placeholder: "_(___) ___-____",
    showMaskOnHover: false,
    autoUnmask: true,
});


$(".phone-mask").keydown(function () {

    telkontrol($(this));
})

function telkontrol(e) {
    var deger = $(e).val();

    if (deger == "+" || deger == 9) {
        deger = "";
    }


    if (deger.length == 1) {
        if (deger != 0) {

            $(e).val("0(" + deger);
        }
        else {
            $(e).val("0(");
        }

    }


}







$("[rel*=external]").attr("target", "_blank");






function cerezkapat() {
    $(".cc-grower").hide(500);
}





$.post("/CerezGorunum", function (sonuc) {

    if (sonuc) {
        setTimeout(function () {
            $(".popGiris").modal('show');
        }, 3000)
    }


})


$.post("/CerezGorunum2", function (sonuc) {

    if (sonuc) {
        var cerez = $("#cerez").html();

        $("body").append(cerez);

    }


})