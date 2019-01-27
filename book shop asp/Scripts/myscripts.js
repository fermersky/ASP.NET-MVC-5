$(document).ready(function () {
    var arw = $(".arrow")
    arw.on('click', function () {
        var book = $(this).parent().parent();

        if ($(this).hasClass("up")) { /* поднять */
            $(this).removeClass("up");
            $(this).addClass("down");
            $(this).animate({ "bottom": 150 }, 200);


            book.find(".about-book").animate({ "bottom": 0 }, 200);

            book.find(".title-book").animate({ "bottom": 210 }, 200);
            book.find(".fields").animate({ "bottom": 15 }, 200);
            book.find(".head").animate({ "bottom": 120, "width": 0 }, 200);
            book.find(".aut-img").animate({ "top": -50 }, 200);

            book.find(".blue").animate({ "width": 0 }, 200);
            book.find(".red").animate({ "width": 0 }, 200);
            book.find(".yellow").animate({ "width": 0 }, 200);

        } else { /* опустить */
            $(this).removeClass("down");
            $(this).addClass("up");
            $(this).animate({ "bottom": 20 }, 200); 

            book.find(".about-book").animate({ "bottom": -120 }, 200);
            book.find(".title-book").animate({ "bottom": 70 }, 200);
            book.find(".fields").animate({ "bottom": -105 }, 200);
            book.find(".head").animate({ "bottom": 0, "width": 150 }, 200);
            book.find(".aut-img").animate({ "top": 0 }, 200);

            book.find(".blue").animate({ "width": 150 }, 100);
            book.find(".red").animate({ "width": 120 }, 150);
            book.find(".yellow").animate({ "width": 90 }, 100);
        }
    });

   
});