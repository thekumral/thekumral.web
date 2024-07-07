var isRTL = JSON.parse(localStorage.getItem('isRTL'));
if (isRTL) {
  var linkDefault = document.getElementById('style-default');
  var userLinkDefault = document.getElementById('user-style-default');
  linkDefault.setAttribute('disabled', true);
  userLinkDefault.setAttribute('disabled', true);
  document.querySelector('html').setAttribute('dir', 'rtl');
} else {
  var linkRTL = document.getElementById('style-rtl');
  var userLinkRTL = document.getElementById('user-style-rtl');
  linkRTL.setAttribute('disabled', true);
  userLinkRTL.setAttribute('disabled', true);
}
