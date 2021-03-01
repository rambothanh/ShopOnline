
// Ẩn tr khi click icon delete
// Đối với Blazor phải dùng sự kiện click như thế này 
$(document).on('click', '[id^=deleteproduct]', function () {
  //Lấy tổ tiên đầu tiên thỏa điều kiện
  // là thẻ tr
  // thêm classd-none để ẩn đi
  $(this).closest("tr").addClass("d-none");
});

//Hiệu ứng khi di chuột vào icon delete or edit
//Bình thường
//  $("[id^=deleteproduct]").hover(function(){
//     $(this).addClass("text-danger");
//     }, function(){
//      $(this).removeClass("text-danger");
//   });

// Blazor
//deleteproduct
$(document).on({
  mouseenter: function () {
    //stuff to do on mouse enter
    $(this).addClass("text-danger");
  },
  mouseleave: function () {
    //stuff to do on mouse leave
    $(this).removeClass("text-danger");
  }
}, '[id^=deleteproduct]');

//editproduct
$(document).on({
  mouseenter: function () {
    //stuff to do on mouse enter
    $(this).addClass("text-warning");
  },
  mouseleave: function () {
    //stuff to do on mouse leave
    $(this).removeClass("text-warning");
  }
}, '[id^=editproduct]');

