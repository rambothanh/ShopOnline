
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

//--------------------Click add to cart On List View, On Grid view, ... --------------------
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

    AddToCartWhenClick(productId, image, productName, currentPrice, oldPrice, quantity, maxQuantity, maxQuantity);
});//--------------------END Click add tocart--------------------

//Create function add to cart when click
function AddToCartWhenClick(productId, image, productName, currentPrice, oldPrice, quantity, maxQuantity, maxQuantity) {
    //Create a cart, Add to ListCart, Save to LocalStorage
    function CreateCartAndSave(listCart) {
        //Create a cart
        var cart = {
            id: productId,
            image: image,
            productName: productName,
            currentPrice: currentPrice,
            oldPrice: oldPrice,
            quantity: quantity, //click chỗ này mặc định add vào cart 1
            total: currentPrice,
            maxQuantity: maxQuantity

        };
        //add cart
        listCart.push(cart);
        //save localsorage
        localStorage.setItem("listCart", JSON.stringify(listCart));
        UpdateProductCart();
    };
    //Check Browser support for LocalStorge
    if (typeof (Storage) !== "undefined") {
        //Check if existed listCart
        var listCartinLocal = JSON.parse(localStorage.getItem('listCart'));
        //if listCart Existed
        if (listCartinLocal != null) {
            //Check producId in listCartinLocal
            var cartExistListCart = containsCart(productId, listCartinLocal);
            //console.log(cartExistListCart);
            if (cartExistListCart != null) {
                //If quantity in Cart = maxQuantity
                if (cartExistListCart.quantity == maxQuantity) return;
                var totalQuantity = Number(cartExistListCart.quantity) + Number(quantity);
                //Check if quantity in Cart >= quantity in database
                if (totalQuantity >= maxQuantity) cartExistListCart.quantity = maxQuantity;
                else cartExistListCart.quantity = totalQuantity;

                cartExistListCart.total = (+cartExistListCart.currentPrice) * (+cartExistListCart.quantity);
                localStorage.setItem("listCart", JSON.stringify(listCartinLocal));
                UpdateProductCart();
            } else {
                CreateCartAndSave(listCartinLocal);
            }
            //if listCart is not existed 
        } else {
            //Create a new listCart
            var listCart = [];
            CreateCartAndSave(listCart);
        }
    } else {
        // Sorry! No Web Storage support..
    }
    //Reload page to js known new content
    //location.reload();
};//Endfunction add to cart when click

