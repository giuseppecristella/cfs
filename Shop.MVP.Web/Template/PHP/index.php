<?php

define( 'ROOT', dirname(__FILE__) );

$page_name = isset( $_GET['page'] ) ? $_GET['page'] : 'home';
$page = ROOT . '/pages/' . $page_name . '.php';

if( $page_name == 'home-2' ) {
    $header = 'header-2.php';
    $footer = 'footer-2.php';
} elseif ( $page_name == 'home' ) {
    $header = 'header.php';
    $footer = 'footer.php';
} else {
    $header = ( isset($_GET['header'] ) && $_GET['header'] == 'dark' ) ? 'header-2.php' : 'header.php' ;
    $footer = ( isset( $_GET['footer'] ) && $_GET['footer'] == '1' ) ? 'footer.php' : 'footer-2.php' ;
}

$header = ROOT . '/parts/general/' . $header;
$footer = ROOT . '/parts/general/' . $footer;

$pages = array(
    'about-us'          => 'About Us',
    'blog'              => 'Blog',
    'catalog'           => 'Catalog',
    'categories-grid'   => 'Categories',
    'checkout'          => 'Checkout',
    'contact-2'         => 'Contact v2',
    'contact'           => 'Contact v1',
    'home'              => 'Home v1',
    'home-2'            => 'Home v2',
    'blog-post'         => 'Blog Post',
    'bewear-icons'      => 'Icons',
    'lookbook-2'        => 'Lookbook v2',
    'lookbook'          => 'Lookbook v1',
    'product-extended'  => 'Product Extended',
    'product-simple'    => 'Product Simple',
    'single-look-2'     => 'Single Look v2',
    'single-look'       => 'Single Look v1',
);
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title><?php echo $pages[$page_name];?> | Bewear</title>
    <!-- Bootstrap -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/css/jasny-bootstrap.min.css" rel="stylesheet">
    <link href="assets/css/lightbox.css" rel="stylesheet">
    <link href="assets/css/bewear-icons.css" rel="stylesheet">
    <link href="assets/css/animate.min.css" rel="stylesheet">
    <link href="assets/css/owl.carousel.css" rel="stylesheet">
    <link href="assets/css/main.min.css" rel="stylesheet">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css">

    <!-- Favicon -->
    <link rel="shortcut icon" href="assets/images/favicon.png">
</head>
<body>
    <div class="wrapper">
        
        <?php if($page_name == 'home'): ?>
            <?php require ROOT . '/parts/general/slider.php'; ?>
        <?php endif; ?>

        <?php
            if (isset ($_GET['parts'] ) ) {
                require ROOT . '/parts/' . $_GET['parts'] ;
            } else {
                require $header;
                require $page;
                require $footer;
            }
        ?>
        <?php require ROOT .'/parts/general/modal-quick-view.php'; ?>

    </div><!-- /.wrapper -->
    <?php require ROOT . '/parts/general/shopping-cart-offcanvas.php'; ?>
    <div class="overlay"></div>

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="assets/js/jquery-1.11.2.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/jasny-bootstrap.min.js"></script>
    <script src="assets/js/bootstrap-hover-dropdown.min.js"></script>
    <script src="assets/js/wow.min.js"></script>
    <script src="assets/js/jquery-ui.min.js"></script>
    <script src="assets/js/echo.min.js"></script>
    <script src="assets/js/lightbox.min.js"></script>
    <script src="assets/js/jquery.easing-1.3.min.js"></script>
    <script src="assets/js/owl.carousel.min.js"></script>
    <script src="assets/js/jquery.customSelect.min.js"></script>
    <script src="assets/js/jquery.bxslider.min.js"></script>
    <script src="assets/js/jquery.isotope.min.js"></script>
    <script src="assets/js/pace.min.js"></script>
    <script src="assets/js/odometer.min.js"></script>
    <script src="assets/js/scripts.js"></script>
</body>
</html>
