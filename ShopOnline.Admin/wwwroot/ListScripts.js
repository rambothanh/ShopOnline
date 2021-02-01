// Trang html bình thường thì dùng như vậy là được
// $("[id^=deleteproduct]").click(function(){
//     //Lấy tổ tiên đầu tiên thỏa điều kiện
//     // là thẻ tr
//     // thêm classd-none để ẩn đi
//     $(this).closest("tr").addClass("d-none");
 
//  });

// Đối với Blazor phải dùng sự kiện click như thế này 
 $(document).on('click','[id^=deleteproduct]', function () {
   //Lấy tổ tiên đầu tiên thỏa điều kiện
    // là thẻ tr
    // thêm classd-none để ẩn đi
    $(this).closest("tr").addClass("d-none");
});