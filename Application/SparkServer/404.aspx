<% Response.StatusCode = 404 %>

<!DOCTYPE html>

<html lang="en-us">
    <head>
        <title>404 - Sitecore Spark</title>

        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
        <meta name="description" content="Sitecore 101 for .NET Developers - Practical Sitecore by Example">
        <meta name="author" content="Brandon Bruno">

        <!--[if lt IE 9]>
            <script src="/Scripts/html5shiv.js"></script>
        <![endif]-->

        <link rel="stylesheet" href="/Content/Styles/reset.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Styles/fonts/fonts.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Styles/fonts/font-awesome.min.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Styles/default.css" type="text/css" />
        <link rel="stylesheet" href="/Content/Styles/highlightjs/github.css" type="text/css" />

        <link rel="shortcut icon" href="/favicon.ico" />
        <link rel="icon" type="image/png" sizes="32x32" href="/favicon-32x32.png">
        <link rel="icon" type="image/png" sizes="96x96" href="/favicon-96x96.png">
        <link rel="icon" type="image/png" sizes="16x16" href="/favicon-16x16.png">

        <!--[if lt IE 9]>
            <link rel="stylesheet" href="/Content/Styles/default.css" type="text/css" />
        <![endif]-->
    </head>

    <body>

        <div class="content">

            <header>
                <a href="/">
                    <img src="~/Content/Images/logo_title.png" alt="Sitecore Spark Logo" class="logo" />
                </a>
                <a class="mobile-menu-toggle"><i class="fa fa-bars" aria-hidden="true"></i> Menu</a>
            </header>

            <nav>
                <ul class="cf">
                    <li><a href="/category"><i class="fa fa-book" aria-hidden="true"></i> Articles</a></li>
                    <li><a href="/resources"><i class="fa fa-share-alt" aria-hidden="true"></i> Resources</a></li>
                    <li><a href="/about"><i class="fa fa-info-circle" aria-hidden="true"></i> About</a></li>
                    <li><a href="/blog"><i class="fa fa-lightbulb-o" aria-hidden="true"></i> Blog</a></li>
                </ul>
            </nav>

            <div class="container cf">

                <h1>Oops, Nothing Here</h1>
                <h2>This is a custom 404 page.</h2>

                <p>Although your Sitecore Spark content wasn't found, seeing this message is still way, way, way better than seeing this:</p>
                
                <div style="text-align: center;">
                    <img src="/Content/Images/sitecore_404.png" alt="A really bad Sitecore 404 page." style="box-shadow: 0 0 24px #999; margin: 0 auto;" />
                </div>

            </div>

        </div>

        <footer class="page">
            <div class="content">
                <ul class="grid two-up cf" style="margin-bottom: 0;">
                    <li>
                        <p><i class="fa fa-twitter" aria-hidden="true"></i> <a href="https://www.twitter.com/sitecorespark" target="_blank">@SitecoreSpark</a></p>
                        <p><i class="fa fa-slack" aria-hidden="true"></i> @brandon.bruno</p>
                        <p><i class="fa fa-envelope" aria-hidden="true"></i> <a href="mailto:bmbruno+sitecorespark@gmail.com">bmbruno+sitecorespark@gmail.com</a></p>
                    </li>
                    <li>
                        <p>Copyright Sitecore Spark. All rights reserved.</p>
                        <p>Not affiliated with <a href="http://www.sitecore.net">Sitecore Corporation A/S</a>. Sitecore&reg; and Own the Experience&reg; are registered U.S. trademarks.</p>
                    </li>
                </ul>
            </div>

        </footer>

        <script src="/Scripts/jquery.js"></script>
        <script src="/Scripts/default.js"></script>
       
        <script>
			(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
			(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
			m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
			})(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

			ga('create', 'UA-82475706-1', 'auto');
			ga('send', 'pageview');
        </script>

    </body>
</html>