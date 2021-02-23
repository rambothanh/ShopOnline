//#region -------- Cart 
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
    UpdateProductCart();
});//--------------------END Click add tocart--------------------

//#endregion ------------- Cart -----------------

//#region -------- waiting for delete
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

//#region -------- Wishlist 
$(document).on('click', "[data-original-title='Add to Wishlist'], div.action a.wishlist", function () {

    //Go to Add to Cart button to get info
    let aAddToCart = $(this).parent().prev();
    //if being wishlist of list view (grid3 page) and Single page
    if ($(this).hasClass("wishlist")) {

        aAddToCart = aAddToCart.children();

    } else {
        aAddToCart = aAddToCart.prev().children();
    }
    //Get info of product on a Add to Cart
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
    if (confirm('Product has added to your Wishlist. Click "OK" to to to Wishlist page, "Cancel" to continue shopping?')) {
        // Go to Wishlist page
        let root = window.location.origin;
        window.location.href = root + "/Wishlist";
    } else {
        // Do nothing
        // console.log('Continue shopping');
    }
});
//#endregion ------------------Wishlist -------------------

//#region -------- Compare 
$(document).on('click', "[data-original-title='Compare']", function () {

    //Go to Add to Cart button to get info
    let aAddToCart = $(this).parent().prev();
    //if being compare of list view (grid3 page)
    if ($(this).hasClass("compare")) {

        aAddToCart = aAddToCart.prev().children();
        //if being compare of Single product
    } else {
        aAddToCart = aAddToCart.children();
    }
    //Get info of product on a Add to Cart
    let maxQuantity = aAddToCart.attr("maxQuantity");
    let productId = aAddToCart.attr("productId");
    let productName = aAddToCart.attr("productName");
    let currentPrice = aAddToCart.attr("currentPrice");
    let oldPrice = aAddToCart.attr("oldPrice");
    let image = aAddToCart.attr("image");
    let quantity = 1;
    let itemLocal = {
        name: "compares",
        list: []
    }
    AddProductToLocal(itemLocal, productId, image, productName, currentPrice, oldPrice, quantity, maxQuantity);
    // confirm go to Wishlist page
    if (confirm('Product has added to your compare. Click "OK" to to to Compare page, "Cancel" to Continue shopping?')) {
        // Go to Wishlist page
        let root = window.location.origin;
        window.location.href = root + "/compare";
    } else {
        // Do nothing
        // console.log('Continue shopping');
    }
});
//#endregion ----- Compare

//#region -------- Function 
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

//Function DELETE PRODUCT IN Local
function DeleteProductInLocal(productId, nameItemList) {
    //Get List
    var listProductInLocal = JSON.parse(localStorage.getItem(nameItemList));
    console.log(listProductInLocal);
    console.log(productId);
    //remove cart with productId
    listProductInLocal = listProductInLocal.filter(p => p.id !== productId);
    console.log(listProductInLocal);
    //save to LocalStorage
    localStorage.setItem(nameItemList, JSON.stringify(listProductInLocal));
};//END Function DELETE PRODUCT IN Local

//Update Wishlist page and Cart page
function Updatelist(nameItemList) {
    //Get List
    var listInLocal = JSON.parse(localStorage.getItem(nameItemList));

    //table body in page
    var tbodyProductInPage = $("div.cart-table tbody");

    // Total value in Cart page
    let subTotalOnCartPage = $('p.price');
    //calculate
    var calculate = CalculateItem(listInLocal);
    if (calculate.totalQuanlity === 0) {
        tbodyProductInPage.text("");
        subTotalOnCartPage.text("$0.00");
    } else {
        //Clear table body
        tbodyProductInPage.text("");
        //Add Total value in Cart page
        subTotalOnCartPage.text("$" + calculate.totalValue);
        listInLocal.forEach(function (product) {
            //product:
            //////id: "1"
            //////image: "...."
            //////currentPrice: ...,
            //////oldPrice: ...,
            //////productName: "Iphone 7 Plus"
            //////quantity: 4
            //////total: 1952
            let trProductInPage = `
                <tr productid=` + product.id + ` >
                    <td class="image">
                        <img src=` + window.location.origin + `/` + product.image + ` alt="">
                    </td>
                    <td class="product">
                        <a href="shopsingle/`+ product.id + `">` + product.productName + `</a>
                        <!-- <span>white</span>-->
                    </td>
                    <td class="price">
                        <span class="amount">$` + product.currentPrice + `</span>
                    </td>
                    <td class="quantity">
                        <form action="#">
                            <div class="quantity d-inline-flex">
                                <button type="button" class="sub"><i class="ti-minus"></i></button>
                                <input max=` + product.maxQuantity + `
                                currentPrice=` + product.currentPrice + `
                                type="text" value=` + product.quantity + ` />
                                <button type="button" class="add"><i class="ti-plus"></i></button>
                            </div>
                        </form>
                    </td>
                    <td class="total">
                        <span class="total-amount">$` + product.total + `</span>
                    </td>
                    <td class="remove">
                        <a><i productid=` + product.id + ` class="ti-close"></i></a>
                    </td>
                </tr>`;

            tbodyProductInPage.append(trProductInPage);
        });
    }
};//Update Wishlist page and Cart page

function UpdateCompare(nameItemList) {
    //Get List
    let listInLocal = JSON.parse(localStorage.getItem(nameItemList));
    //table body in page
    let tbodyProductInPage = $("div.compare-table tbody");
    let trCompareList = {
        product: "<tr><th>Product</th>",
        price: "<tr><th>Price</th>",
        color: "<tr><th>Color</th>",
        stock: "<tr><th>Stock</th>",
        addToCart: "<tr><th>Add to cart</th>",
        delete: "<tr><th>Delete</th>",
        rating: "<tr><th>Rating</th>",
    };
    //calculate
    var calculate = CalculateItem(listInLocal);
    if (calculate.totalQuanlity === 0) {
        tbodyProductInPage.html(`
        <p class="info-header">
            <i class="fa fa-exclamation-circle"></i>
            There are no products to compare!
            <a href=` + window.location.origin + `/ShopGrid3` + ` >Continue shopping!</a>
        </p>`);
    } else {
        //Clear table body
        tbodyProductInPage.text("");
        listInLocal.forEach(function (product) {
            //product:
            //////id: "1"
            //////image: "...."
            //////currentPrice: ...,
            //////oldPrice: ...,
            //////productName: "Iphone 7 Plus"
            //////quantity: 4
            //////total: 1952
            trCompareList.product += `
                <td>
                    <div class="product-image-title">
                        <a class="product-image" href=` + window.location.origin + `/shopsingle/` + product.id + `><img
                                src=` + window.location.origin + `/` + product.image + ` alt="product"></a>
                        <a class="category">Update later</a>
                        <h5 class="title"><a href=` + window.location.origin + `/shopsingle/` + product.id + `>` + product.productName + `</a></h5>
                    </div>
                </td>`;
            trCompareList.price += `<td>$` + product.currentPrice + `</td>`;
            trCompareList.color += `<td>Update later</td>`;
            trCompareList.stock += `<td>Update later</td>`; //Will fixed later
            trCompareList.addToCart += `
                <td><a productId=`+ product.id + ` 
                productName=`+ product.productName + ` 
                currentPrice=`+ product.currentPrice + ` 
                oldPrice=`+ product.oldPrice + ` 
                maxQuantity=`+ product.quantity + ` 
                image=`+ product.image + `
                class="btn btn-primary">Add to Cart</a></td>`;
            trCompareList.delete += `<td><a productId=` + product.id + ` class="delete"><i class="fa fa-trash"></i></a></td>`; //Will fixed later
            trCompareList.rating += ` 
                <td>
                    <ul class="rating">
                        <li class="rating-on"><i class="fa fa-star"></i></li>
                        <li class="rating-on"><i class="fa fa-star"></i></li>
                        <li class="rating-on"><i class="fa fa-star"></i></li>
                        <li class="rating-on"><i class="fa fa-star"></i></li>
                        <li class=""><i class="fa fa-star"></i></li>
                    </ul>
                </td>`; //Will fixed later
        });
        console.log(trCompareList.product);
        tbodyProductInPage.append(trCompareList.product + "</tr>");
        tbodyProductInPage.append(trCompareList.price + "</tr>");
        tbodyProductInPage.append(trCompareList.color + "</tr>");
        tbodyProductInPage.append(trCompareList.stock + "</tr>");
        tbodyProductInPage.append(trCompareList.addToCart + "</tr>");
        tbodyProductInPage.append(trCompareList.delete + "</tr>");
        tbodyProductInPage.append(trCompareList.rating + "</tr>");
    }

};
//#endregion ----- Function