let baseAPI = "http://localhost:5000/api/";

//#region -------- AJAX get many product
$(document).ready(function () {

    // if (!sessionStorage.hasOwnProperty("token")) {
    //    window.location.href = "Chuyển qua trang đăng nhập";
    //} 
    var options = {};
    options.url = baseAPI + "Products";
    options.type = "GET";
    //options.beforeSend = function (xhr) {
    //    xhr.setRequestHeader("Authorization", "Bearer " + sessionStorage.getItem("token"));
    //    $("h3.message").html("Wait...");
    //}; 
    options.dataType = "json";
    options.success = function (data) {
        //Add to New Product, Quick View (index page )and Get Array <div class="single-product">
        let arrDivSingleProduct = [];
        let root = window.location.origin + "/";
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
                            <a href="`+ root + `shopsingle/` + product.id + `">
                                <img src="`+ root + mainProductImage + `" alt="">
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
                                    <li><a data-tooltip="tooltip" data-placement="left" title="Compare"><i class="icon-sliders"></i></a></li>
                                    <li><a data-tooltip="tooltip" data-placement="left" title="Add to Wishlist"><i class="icon-heart"></i></a></li>
                                    <li><a data-tooltip="tooltip" data-placement="left" title="Quick View" data-toggle="modal" data-target="#Modal`+ product.id + `"><i class="icon-eye"></i></a></li>
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
                            <h4 class="product-name"><a href="`+ root + `shopsingle/` + product.id + `">` + product.name + `</a></h4>
                            <div class="price-box">
                                <span class="current-price">$`+ product.productPrice.currentPrice + `</span>
                                <span class="old-price">$`+ product.productPrice.oldPrice + `</span>
                            </div>
                        </div>
                  </div>`;
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
                                            <img src="`+ root + mainProductImage + `" alt="">
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
            //Add quickView  (index page and Grid 3 page)
            $("div.main-wrapper").prepend(quickView);
            //Add to listDivSingleProduct
            arrDivSingleProduct.push(divSingleProduct);
            //#region Create and Add product list view (Grid 3 page)
            if ($("div#list").length > 0) {
                let divProductList = `
                <div class="single-product product-list">
                    <div class="product-image">
                        <a href="`+ root + `shopsingle/` + product.id + `">
                            <img src="`+ mainProductImage + `" alt="">
                        </a>
    
                        `+ stickerNew + `
    
                        <div class="action-links">
                            <ul>
                                <li><a href="javascript:void(0);" data-tooltip="tooltip" data-placement="left" title="Quick View" data-toggle="modal" data-target="#Modal`+ product.id + `"><i class="icon-eye"></i></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="product-content">
                        <ul class="rating">
                            <li class="rating-on"><i class="fa fa-star-o"></i></li>
                            <li class="rating-on"><i class="fa fa-star-o"></i></li>
                            <li class="rating-on"><i class="fa fa-star-o"></i></li>
                            <li class="rating-on"><i class="fa fa-star-o"></i></li>
                            <li class="rating-on"><i class="fa fa-star-o"></i></li>
                        </ul>
                        <h4 class="product-name"><a href="`+ root + `shopsingle/` + product.id + `">` + product.name + `</a></h4>
                        <div class="price-box">
                            <span class="current-price">$`+ product.productPrice.currentPrice + `</span>
                            <span class="old-price">$`+ product.productPrice.oldPrice + `</span>
                        </div>
                        <p>`+ product.shortDescription + `</p>
    
                        <ul class="action-links">
                            <li><a productId=`+ product.id + ` 
                                    productName=`+ product.name + ` 
                                    currentPrice=`+ product.productPrice.currentPrice + ` 
                                    oldPrice=`+ product.productPrice.oldPrice + ` 
                                    maxQuantity=`+ product.quantity + `
                                    image=`+ mainProductImage + `
                                    class="add-cart" data-tooltip="tooltip" data-placement="top" title="Add to cart"> Add to cart </a></li>
                            <li><a href="javascript:void(0);" data-tooltip="tooltip" data-placement="top" title="Add to Wishlist" class="wishlist"><i class="icon-heart"></i></a></li>
                            <li><a href="javascript:void(0);" data-tooltip="tooltip" data-placement="top" title="Compare" class="compare"><i class="icon-sliders"></i></a></li>
                        </ul>
                    </div>
                </div>`;
                $("div#list").prepend(divProductList);
            }

            //#endregion Create product list view
        });
        let arrLen = arrDivSingleProduct.length;
        //#region Add to New Products (index page) and Related Products (on ShopSingle)
        let newProducts = $("div.new-product-area div.swiper-wrapper");
        if (newProducts.length > 0) {
            for (let i = 0; i < arrLen; i++) {
                //#region Create <div class="swiper-slide">
                let divswiperSlide = document.createElement("div");
                divswiperSlide.className = "swiper-slide";
                divswiperSlide.innerHTML = arrDivSingleProduct[i];
                //#endregion
                //Add to New Product on Index page
                newProducts.prepend(divswiperSlide);
            }
        }
        //#endregion Add to New Product (index page)
        //#region Add to Featured (index page)
        //Chỉ lấy 10 sản phẩm đầu để demo
        if ($("#tab1 div.swiper-wrapper").length > 0) {
            for (let i = 0; i < 10 / 2; i++) {
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
                divswiperSlideBestSeller.innerHTML = arrDivSingleProduct[2 * (i + 1) - 1] + arrDivSingleProduct[2 * (i + 1) - 2];
                //#endregion
                //Add New in Featured (index page)
                $("#tab1 div.swiper-wrapper").prepend(divswiperSlide);
                //Add Featured in Featured (index page)
                $("#tab2 div.swiper-wrapper").prepend(divswiperSlideReverse);
                //Add Featured in Featured (index page)
                $("#tab3 div.swiper-wrapper").prepend(divswiperSlideBestSeller);
            }
        }
        //#endregion Add to Featured (index page)
        //#region Add Gird view and List View (Grid 3 page)
        let grid3 = $("#grid > div");
        //If being Grid3 page
        if (grid3.length > 0) {

            for (let i = 0; i < arrLen; i++) {

                //Create <div class="col-lg-4 col-sm-6">
                let divcollg4colsm6 = document.createElement("div");
                divcollg4colsm6.className = "col-lg-4 col-sm-6";
                divcollg4colsm6.innerHTML = arrDivSingleProduct[i];
                //add to ("#grid > div") in Grid 3 page
                grid3.prepend(divcollg4colsm6);
            }
        }
        //#endregion Add Gird view and List View (Grid 3 page)
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
//#endregion ----- AJAX get many product
//#region -------- AJAX for Single Page (one Product by ID) ---------------
// if being shopSingle:
if (typeof idProduct_shopSingle_global !== "undefined") {
    //Get domain name with UpperCase first letter
    let domainName = window.location.hostname;
    let con = domainName[0].toUpperCase();
    domainName = domainName.replace(domainName[0], con);
    //------------------End get domain name
    $(document).ready(function () {
        //-------------------AJAX------------------------
        //  if (!sessionStorage.hasOwnProperty("token")) {
        //     window.location.href = "Chuyển qua trang đăng nhập";
        // } 
        var options = {};
        options.url = baseAPI + "Products/" + idProduct_shopSingle_global;
        options.type = "GET";
        //    options.beforeSend = function (xhr) {
        //         xhr.setRequestHeader("Authorization", "Bearer " + sessionStorage.getItem("token"));
        //         $("h3.message").html("Wait...");
        //     }; 
        options.dataType = "json";
        options.success = function (product) {
            //Handle this
            //product.name;
            var title = $("div.row.justify-content-center h3");
            title.text(product.name); //add to title
            //Change title to Product name
            $("div.page-banner-content h2.title").text(product.name);//add to panner
            $("title").text(product.name + " | " + domainName);//add to head
            //Add Price: div.thumb-price
            var price = title.next().next().next();
            //product.productPrice.currentPrice
            price.children("span.current-price").text("$" + product.productPrice.currentPrice);
            //product.productPrice.oldPrice
            price.children("span.old-price").text("$" + product.productPrice.oldPrice);
            //product.productPrice.salePercent
            price.children("span.discount").text("-" + product.productPrice.salePercent + "%");
            //product.shortDescription
            //class: product-quantity d-flex flex-wrap align-items-center
            var shortDescription = price.next();
            shortDescription.text(product.shortDescription);
            //product.quantity
            var quantity = shortDescription.next().next();
            quantity.find("input").attr("max", product.quantity);
            if (product.quantity === 0) {
                quantity.find("input").attr("value", 0);
            }

            //class: product-action d-flex flex-wrap
            var productAction = quantity.next();
            //Add info Product to button add to cart
            let buttonAddtoCart = productAction.find("button");
            buttonAddtoCart.attr("productId", product.id);
            buttonAddtoCart.attr("maxQuantity", product.quantity);
            buttonAddtoCart.attr("productName", product.name);
            buttonAddtoCart.attr("currentPrice", product.productPrice.currentPrice);
            buttonAddtoCart.attr("oldPrice", product.productPrice.oldPrice);
            buttonAddtoCart.attr("image", product.mainProductImage);

            //product.productImages.pictureUri
            //div.col-lg-6
            var divImage = title.parent().parent();
            //div.col-lg-6.col-md-8
            var divcollg6colmd8 = divImage.prev();
            //add salePercent
            divcollg6colmd8.find("span.sticker-new").text("-" + product.productPrice.salePercent + "%");
            var divSwiper = divcollg6colmd8.find("div.swiper-wrapper");

            //Add 4 image to div.swiper-wrapper
            var numberImage = 1;
            product.productImages.forEach(function (productImage) {
                if (!productImage.isMainPicture) {
                    let root = window.location.origin + "/";
                    var linkImage = root.concat(productImage.pictureUri);
                    //add a image to <img class="product-zoom"
                    divcollg6colmd8.find("img.product-zoom").attr("src", linkImage)
                    //divImage.prev().find("img.product-zoom").attr("src", linkImage);
                    //#Image1 = $("div.row.justify-content-center h3").parent().parent().prev().find("div.swiper-wrapper").children()[0]
                    //Add a Image to #Image"1,2,3,4"
                    var divImage = divSwiper.find("div#Image".concat(+numberImage)).children();
                    divImage.attr("data-image", linkImage);
                    divImage.children("img").attr("src", linkImage);
                    numberImage = +numberImage + 1;

                } else {
                    //add image to button
                    productAction.find("button").attr("image", productImage.pictureUri);
                }
            });

            //product.productType
            //product.productBrand

            //product.description;
            //div.shop-single-info
            var divInfo = divImage.parent().next();
            divInfo.find("div.description p").text(product.description);

            //Error message change to ""
            // $("h3.message").html("");
            //  if (sessionStorage.hasOwnProperty("message")) {
            //     $("h3.message").html(sessionStorage.getItem("message"));
            //     sessionStorage.removeItem("message");
            // } 

        };//end options.success
        options.error = function (xhr) {
            // if (xhr.status == 401) {
            //     window.location.href = "/EmployeeManager/SignIn";
            // }

            // $("h3.message").html("Error while calling the API");
        }
        //Start call API
        $.ajax(options);
    });
    //console.log(model);
    //console.log(shopSingleModel_global.Id);
}
//#endregion ------------- AJAX for Single Page ---------------
