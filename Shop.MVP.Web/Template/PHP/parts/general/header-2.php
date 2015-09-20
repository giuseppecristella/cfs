<header> 
	<div class="navbar navbar-black">
		<div class="navbar-header">
			<div class="container">
				<!-- ============================================================= LOGO MOBILE ============================================================= -->
						
				<a class="navbar-brand" href="index.php?page=home"><img src="assets/images/logo2.png" class="logo" alt=""></a>
						
				<!-- ============================================================= LOGO MOBILE : END ============================================================= -->
						
				<a class="btn responsive-menu pull-right" data-toggle="collapse" data-target=".navbar-collapse">					
					<div class="bar"></div>
					<div class="bar"></div>
					<div class="bar"></div>					
				</a>
			</div><!-- /.container -->
		</div><!-- /.navbar-header -->
		
		<div class="yamm">
			<div class="navbar-collapse collapse animate-dropdown">
				<div class="container">
					<a href="#" class="navbar-brand"><img src="assets/images/logo2.png" class="logo" alt=""></a>
					<ul class="nav navbar-nav">
						<li class="dropdown bewear-dropdown yamm-fw">
							<a href="index.php?page=home" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Ladies </span></a>
							<ul class="dropdown-menu bewear-dropdown-menu">
								<li class="dropdown yamm-fw">
									<?php require ROOT . '/parts/navigation/megamenu-ver1.php'; ?>
								</li>
							</ul>
						</li>

						<li class="dropdown bewear-dropdown yamm-fw">
							<a href="index.php?page=home" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Men</span></a>
							<ul class="dropdown-menu bewear-dropdown-menu">
								<li class="dropdown yamm-fw">
									<?php require ROOT . '/parts/navigation/megamenu-ver2.php'; ?>
								</li>
							</ul>
						</li>

						<li class="dropdown bewear-dropdown"><a href="index.php?page=home" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Look Book</span></a>
							<ul class="dropdown-menu bewear-dropdown-menu">
								<li><a href="index.php?page=lookbook">Look Book</a></li>
								<li><a href="index.php?page=single-look">Single Look</a></li>
								<li><a href="index.php?page=lookbook-2">Look Book-2</a></li>
								<li><a href="index.php?page=single-look-2">Single Look-2</a></li>
							</ul>
						</li>

						<li class="dropdown bewear-dropdown">
							<a href="index.php?page=home" data-hover="dropdown" class="dropdown-toggle" data-toggle="dropdown"><span>Insider</span></a>
							<?php require ROOT . '/parts/navigation/page-list.php'; ?>
						</li>
					</ul>
					<ul class="nav navbar-nav navbar-right">
						<li class="dropdown searchbox bewear-dropdown"><a href="#" data-hover="dropdown" class="no-drop-icon dropdown-toggle" data-toggle="dropdown"><i class="icon icon-search"></i></a>				  
							<div class="dropdown-menu bewear-dropdown-menu">
								<form id="search" class="navbar-form search" role="search">
									<input type="search" class="form-control" placeholder="Type to search">
									<button type="submit" class="btn btn-primary btn-submit icon icon-search"></button>
								</form>
							</div><!-- /.dropdown-menu -->
						</li><!-- /.searchbox -->
						
						<li><a href="#"><i class="icon icon-user"></i></a></li>
						<li><a id="menu-toggle" class="navbar-toggle shopping-cart-toggle" data-toggle="offcanvas" data-target="#shopping-cart-summary" href="#"><i class="icon icon-shopbag"></i><span class="item-count">5</span></a></li>
					</ul>
				</div>
			</div><!-- /.navbar-collapse -->
		</div><!-- /.yamm -->
	</div><!-- /.navbar -->
</header><!-- /header -->