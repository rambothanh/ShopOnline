$(document).ready(function () {
    //-------------- AJAX ---------------------
    // if (!sessionStorage.hasOwnProperty("token")) {
    //    window.location.href = "Chuyển qua trang đăng nhập";
    //} 
    var options = {};
    options.url = "http://localhost:5000/api/Products";
    options.type = "GET";
    //options.beforeSend = function (xhr) {
    //    xhr.setRequestHeader("Authorization", "Bearer " + sessionStorage.getItem("token"));
    //    $("h3.message").html("Wait...");
    //}; 
    options.dataType = "json";
    options.success = function (data) {
        //Add to New Product, Quick View (index page )and Get Array <div class="single-product">
        let arrDivSingleProduct = [];
        data.forEach(function (product) {
            //Check quantity of product
            if (product.quantity === 0) {
                var stickerNew = `<span class="sticker-new soldout-title">Soldout</span>`;
            } else {
                var stickerNew = `<span class="sticker-new label-sale">-` + product.productPrice.salePercent + `%</span>`;
            }
            //MainProductImage 
            var mainProductImage = "";
            product.productImages.forEach(function (productImage) {
                if (productImage.isMainPicture) {
                    mainProductImage = productImage.pictureUri;
                    //break; JAVASCRIPT can't break forEach
                }
            });

            //#region Create div class="single-product
            let divSingleProduct = `
                    <div class="single-product">
                        <div class="product-image">
                            <a href="shopsingle/`+ product.id + `">
                                 <img src="`+ mainProductImage + `" alt="">
                            </a>
                            `+ stickerNew + `
                            <div class="action-links">
                                <ul>
                                    <li><a productId=`+ product.id + ` 
                                    productName=`+ product.name + ` 
                                    currentPrice=`+ product.productPrice.currentPrice + ` 
                                    oldPrice=`+ product.productPrice.oldPrice + ` 
                                    maxQuantity=`+ product.quantity + `
                                    image=`+ mainProductImage + ` 
                                    data-tooltip="tooltip" data-placement="left" title="Add to cart"><i class="icon-shopping-bag"></i></a></li>
                                    <li><a href="compare.html" data-tooltip="tooltip" data-placement="left" title="Compare"><i class="icon-sliders"></i></a></li>
                                    <li><a href="wishlist.html" data-tooltip="tooltip" data-placement="left" title="Add to Wishlist"><i class="icon-heart"></i></a></li>
                                    <li><a href="javascript:void(0);" data-tooltip="tooltip" data-placement="left" title="Quick View" data-toggle="modal" data-target="#Modal`+ product.id + `"><i class="icon-eye"></i></a></li>
                                </ul>
                            </div>

                        </div>
                        <div class="product-content text-center">
                            <ul class="rating">
                                <li class="rating-on"><i class="fa fa-star"></i></li>
                                <li class="rating-on"><i class="fa fa-star"></i></li>
                                <li class="rating-on"><i class="fa fa-star"></i></li>
                                <li class="rating-on"><i class="fa fa-star-half-o"></i></li>
                                <li class="rating-on"><i class="fa fa-star-o"></i></li>
                            </ul>
                            <h4 class="product-name"><a href="shopsingle/`+ product.id + `">` + product.name + `</a></h4>
                            <div class="price-box">
                                <span class="current-price">$`+ product.productPrice.currentPrice + `</span>
                                <span class="old-price">$`+ product.productPrice.oldPrice + `</span>
                            </div>
                        </div>
                  </div>`;
            //#endregion
            //#region Create <div class="swiper-slide">
            let divswiperSlide = document.createElement("div");
            divswiperSlide.className = "swiper-slide";
            divswiperSlide.innerHTML = divSingleProduct;
            //#endregion
            //#region Create <div class="modal fade" id="Modal`+ product.id + `">
            var quickView = `
                <div class="modal fade" id="Modal`+ product.id + `">
                    <div class="modal-dialog modal-dialog-centered">
                        <div class="modal-content">
                            <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="quick-view-image">
                                            <img src="`+ mainProductImage + `" alt="">
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="quick-view-content">
                                            <h4 class="product-title">`+ product.name + `</h4>
                                            <div class="thumb-price">
                                                <span class="current-price">$`+ product.productPrice.currentPrice + `</span>
                                                <span class="old-price">$`+ product.productPrice.oldPrice + `</span>
                                                <span class="discount">-`+ product.productPrice.salePercent + `%</span>
                                            </div>
                                            <div class="product-rating">
                                                <ul class="rating-star">
                                                    <li><i class="fa fa-star-o"></i></li>
                                                    <li><i class="fa fa-star-o"></i></li>
                                                    <li><i class="fa fa-star-o"></i></li>
                                                    <li><i class="fa fa-star-o"></i></li>
                                                    <li><i class="fa fa-star-o"></i></li>
                                                </ul>
                                                <span>No reviews</span>
                                            </div>
                                            <p>`+ product.shortDescription + `</p>

                                            <div class="quick-view-quantity-addcart d-flex flex-wrap">
                                                <form action="#">
                                                    <div class="quantity d-inline-flex">
                                                        <button type="button" class="sub"><i class="ti-minus"></i></button>
                                                        <input type="text" value="1" max=`+ product.quantity + ` />
                                                        <button type="button" class="add"><i class="ti-plus"></i></button>
                                                    </div>
                                                </form>
                                                <div class="addcart-btn">
                                                    <button productId=`+ product.id + ` 
                                                            productName=`+ product.name + ` 
                                                            currentPrice=`+ product.productPrice.currentPrice + ` 
                                                            oldPrice=`+ product.productPrice.oldPrice + ` 
                                                            maxQuantity=`+ product.quantity + `
                                                            image=`+ mainProductImage + `
                                                            quickView=true
                                                            class="btn btn-primary">Add to cart</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`;
            //#endregion Create quick view

            //Add to New Product on Index page
            $("div.new-product-area div.swiper-wrapper").append(divswiperSlide);
            //Add quickView
            $("div.main-wrapper").append(quickView);

            //Add to listDivSingleProduct
            arrDivSingleProduct.push(divSingleProduct);
        });

        //#region Add to Featured (index page)
        //Chỉ lấy 10 sản phẩm đầu để demo
        arrLen = 10 / 2;
        for (i = 0; i < arrLen - 1; i++) {

            //#region Create <div class="swiper-slide">
            let divswiperSlide = document.createElement("div");
            let divswiperSlideReverse = document.createElement("div");
            let divswiperSlideBestSeller = document.createElement("div");
            divswiperSlide.className = "swiper-slide";
            divswiperSlideReverse.className = "swiper-slide";
            divswiperSlideBestSeller.className = "swiper-slide";
            //Mỗi swiper-slide là 2 SingleProduct
            divswiperSlide.innerHTML = arrDivSingleProduct[i] + arrDivSingleProduct[10 - 1 - i];
            divswiperSlideReverse.innerHTML = arrDivSingleProduct[10 - 1 - i] + arrDivSingleProduct[i];
            divswiperSlideBestSeller.innerHTML = arrDivSingleProduct[2 * (i + 1)] + arrDivSingleProduct[2 * (i + 1) - 1];
            //#endregion
            //Add New in Featured (index page)
            $("#tab1 div.swiper-wrapper").prepend(divswiperSlide);
            //Add Featured in Featured (index page)
            $("#tab2 div.swiper-wrapper").prepend(divswiperSlideReverse);
            //Add Featured in Featured (index page)
            $("#tab3 div.swiper-wrapper").prepend(divswiperSlideBestSeller);
        }
        //#endregion Add to Featured (index page)
        //#region Error
        //Error message change to ""
        //$("h3.message").html("");

        //if (sessionStorage.hasOwnProperty("message")) {
        //     $("h3.message").html(sessionStorage.getItem("message"));
        //     sessionStorage.removeItem("message");
        // }
        //#endregion Error 
    };
    options.error = function (xhr) {
        //if (xhr.status == 401) {
        //    window.location.href = "chuyển đến trang đăng nhập";
        //} 

        //$("h3.message").html("Error while calling the API");
    }
    //Start call API
    $.ajax(options);
});
    //-------------- END AJAX ---------------------