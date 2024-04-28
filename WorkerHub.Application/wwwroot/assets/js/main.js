(function ($) {
    $(document).on('click', '.secondary-btn', function (e) {
      e.preventDefault();
      $('.primary-section').toggleClass('primary-slide');
      $('.secondary-section').toggleClass('secondary-slide');
      $('body').toggleClass('body-slide');
      $('body').toggleClass('body-slide');
    });
  })(jQuery)

  $(document).ready(function () {
    $('.note-side [data-bs-toggle="collapse"]').click(function () {
      $(this).toggleClass("active");
      if ($(this).hasClass("active")) {
        $(this).text("Hide");
      } else {
        $(this).text("Show");
      }
    });

  });