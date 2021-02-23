/*--
    |    Get Product and add to CART CONTENT
    -----------------------------------*/
function UpdateProductCart() {
    //Get List
    var listCartinLocal = JSON.parse(localStorage.getItem('listCart'));
    //li.product-cart
    var liProductInCart = $("li.product-cart");
    //total value
    var totalValue = liProductInCart.next().children().children().children();
    var calculate = CalculateItem(listCartinLocal);
    if (calculate.totalQuanlity === 0) {
        $('span.item-count').addClass("d-none");
        liProductInCart.text("");
        totalValue.text("");
    } else {
        //Add number total product
        $('span.item-count').removeClass("d-none");
        $('span.item-count').text(calculate.totalQuanlity);
        //Clear li.product-cart
        liProductInCart.text("");
        let root = window.location.origin + "/";
        //Add new li.product-cart
        listCartinLocal.forEach(function (cart) {
            //cart:
            //////id: "1"
            //////image: "...."
            //////currentPrice: ...,
            //////oldPrice: ...,
            //////productName: "Iphone 7 Plus"
            //////quantity: 4
            //////total: 1952
            var divProductInCart = `<div class="single-cart-box">
                                                <div class="cart-img">
                                                    <a href="`+ root + `shopsingle/` + cart.id + `"><img src=` + root + cart.image + ` alt=""></a>
                                                    <span class="pro-quantity">` + cart.quantity + `x</span>
                                                </div>
                                                <div class="cart-content">
                                                    <h6 class="title"><a href="`+ root + `shopsingle/` + cart.id + `">` + cart.productName + `</a></h6>
                                                    <div class="cart-price">
                                                        <span class="sale-price">$` + cart.currentPrice + `</span>
                                                        <span class="regular-price">` + cart.oldPrice + `</span>
                                                    </div>
                                                </div>
                                                <a productid=`+ cart.id + ` href="javascript:void(0);" class="del-icon"><i class="fa fa-trash"></i></a>
                                            </div>`;
            liProductInCart.append(divProductInCart);
        });
        //Add total value of cart
        totalValue.text("$" + calculate.totalValue);
    }
};//End UpdateProductCart 
//Run update when first load
UpdateProductCart();
//--------------DELETE PRODUCT IN CART -------------------
$(document).on('click', 'div.single-cart-box a.del-icon', function () {
    //Get List
    var listCartinLocal = JSON.parse(localStorage.getItem('listCart'));
    //Get Id product
    var productId = $(this).attr("productid");
    //remove cart with productId
    listCartinLocal = listCartinLocal.filter(cart => cart.id !== productId);
    //save to LocalStorage
    localStorage.setItem("listCart", JSON.stringify(listCartinLocal));
    //update
    UpdateProductCart();
    //reload this page
    //location.reload();
}); //--------------END DELETE PRODUCT IN CART -------------------
//Calculate Item count and total Price and add to item-count 
function CalculateItem(listCart) {
    var i;
    var result = {
        totalQuanlity: 0,
        totalValue: 0
    };
    if (listCart === null) return result;
    for (i = 0; i < listCart.length; i++) {
        result.totalQuanlity = Number(result.totalQuanlity) + Number(listCart[i].quantity);
        result.totalValue = Number(result.totalValue) + Number(listCart[i].total);
    }
    return result;
};
//Check idProduct in Listcart
function containsCart(productId, listCart) {
    var i;
    for (i = 0; i < listCart.length; i++) {
        if (listCart[i].id === productId) {
            return listCart[i];
        }
    }
    return null;
};

//--------------------Click add to cart On List View, On Grid view, on Quick View... --------------------
$(document).on('click', '[productName]', function () {
    var maxQuantity = $(this).attr("maxQuantity");
    //if sold out, do nothing
    if (maxQuantity === "0") return;
    var productId = $(this).attr("productId");
    var productName = $(this).attr("productName");
    var currentPrice = $(this).attr("currentPrice");
    var oldPrice = $(this).attr("oldPrice");
    var image = $(this).attr("image");
    var quantity = 1;
    //if is Button at quickview
    if ($(this).attr("quickview") === "true") {
        quantity = $(this).parent().prev().find("input").val();
    }
    let itemLocal = {
        name: "listCart",
        list: []
    };
    AddProductToLocal(itemLocal, productId, image, productName, currentPrice, oldPrice, quantity, maxQuantity);
});//--------------------END Click add tocart--------------------

//#region Chờ xóa
// //Không còn sử dụng function này nữa, để vài bữa nữa xóa
// function AddToCartWhenClick(productId, image, productName, currentPrice, oldPrice, quantity, maxQuantity) {
//     //Create a cart, Add to ListCart, Save to LocalStorage
//     function CreateCartAndSave(listCart) {
//         //Create a cart
//         var cart = {
//             id: productId,
//             image: image,
//             productName: productName,
//             currentPrice: currentPrice,
//             oldPrice: oldPrice,
//             quantity: quantity, //click chỗ này mặc định add vào cart 1
//             total: currentPrice,
//             maxQuantity: maxQuantity

//         };
//         //add cart
//         listCart.push(cart);
//         //save localsorage
//         localStorage.setItem("listCart", JSON.stringify(listCart));
//         UpdateProductCart();
//     };
//     //Check Browser support for LocalStorge
//     if (typeof (Storage) !== "undefined") {
//         //Check if existed listCart
//         var listCartinLocal = JSON.parse(localStorage.getItem('listCart'));
//         //if listCart Existed
//         if (listCartinLocal != null) {
//             //Check producId in listCartinLocal
//             var cartExistListCart = containsCart(productId, listCartinLocal);
//             //console.log(cartExistListCart);
//             if (cartExistListCart != null) {
//                 //If quantity in Cart = maxQuantity
//                 if (cartExistListCart.quantity == maxQuantity) return;
//                 var totalQuantity = Number(cartExistListCart.quantity) + Number(quantity);
//                 //Check if quantity in Cart >= quantity in database
//                 if (totalQuantity >= maxQuantity) cartExistListCart.quantity = maxQuantity;
//                 else cartExistListCart.quantity = totalQuantity;

//                 cartExistListCart.total = (+cartExistListCart.currentPrice) * (+cartExistListCart.quantity);
//                 localStorage.setItem("listCart", JSON.stringify(listCartinLocal));
//                 UpdateProductCart();
//             } else {
//                 CreateCartAndSave(listCartinLocal);
//             }
//             //if listCart is not existed 
//         } else {
//             //Create a new listCart
//             var listCart = [];
//             CreateCartAndSave(listCart);
//         }
//     } else {
//         alert("Sorry! No Web Storage support");
//     }
// };//Endfunction add to cart when click
//#endregion chờ xóa

//#region ------------------Wishlist -------------------
$(document).on('click', "[data-original-title='Add to Wishlist']", function () {
    //if being wishlist of list view (grid3 page)
    let aAddToCart = $(this).parent().prev();
    if ($(this).hasClass("wishlist")) {
        //Get info of product on a Add to Cart
        aAddToCart = aAddToCart.children();

    } else {
        aAddToCart = aAddToCart.prev().children();
    }

    let maxQuantity = aAddToCart.attr("maxQuantity");
    let productId = aAddToCart.attr("productId");
    let productName = aAddToCart.attr("productName");
    let currentPrice = aAddToCart.attr("currentPrice");
    let oldPrice = aAddToCart.attr("oldPrice");
    let image = aAddToCart.attr("image");
    let quantity = 1;
    let itemLocal = {
        name: "wishlists",
        list: []
    }
    AddProductToLocal(itemLocal, productId, image, productName, currentPrice, oldPrice, quantity, maxQuantity);
    // confirm go to Wishlist page
    if (confirm('Product has add to your Wishlist. Go to Wishlist page?')) {
        // Go to Wishlist page
        let root = window.location.origin;
        window.location.href = root + "/Wishlist";
    } else {
        // Do nothing
        // console.log('Continue shopping');
    }
});
//#endregion ------------------Wishlist -------------------

//function add a Product to list in LocalStoreAge
function AddProductToLocal(itemLocal, productId, image, productName, currentPrice, oldPrice, quantity, maxQuantity) {
    //Function use when Create a product, Add to ListCart, Save to LocalStorage
    function CreateproductAndSave(itemLocal) {
        //Create a product
        let product = {
            id: productId,
            image: image,
            productName: productName,
            currentPrice: currentPrice,
            oldPrice: oldPrice,
            quantity: quantity,
            total: currentPrice,
            maxQuantity: maxQuantity
        };
        //add product
        itemLocal.list.push(product);
        //save localsorage
        localStorage.setItem(itemLocal.name, JSON.stringify(itemLocal.list));
    };
    //Check Browser support for LocalStorge
    if (typeof (Storage) !== "undefined") {
        //Check if existed itemLocal
        let productinLocal = JSON.parse(localStorage.getItem(itemLocal.name));
        //if itemLocal Existed
        if (productinLocal != null) {
            //Check producId in productinLocal
            let productExist = containsCart(productId, productinLocal);
            if (productExist != null) {
                //If quantity in product = maxQuantity
                if (productExist.quantity == maxQuantity) return;
                let totalQuantity = Number(productExist.quantity) + Number(quantity);
                //Check if quantity in product >= quantity in database
                if (totalQuantity >= maxQuantity) productExist.quantity = maxQuantity;
                else productExist.quantity = totalQuantity;

                productExist.total = (+productExist.currentPrice) * (+productExist.quantity);
                localStorage.setItem(itemLocal.name, JSON.stringify(productinLocal));
                //If productId is not existed in itemLocal.list
            } else {
                itemLocal.list = productinLocal;
                CreateproductAndSave(itemLocal);
            }
            //if itemLocal.list is not existed in local
        } else {
            CreateproductAndSave(itemLocal);
        }
    } else {
        alert("Sorry! No Web Storage support");
    }
};//End function add a Product to list in LocalStoreAge