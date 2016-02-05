<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bootstrap Learn</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/Custom-Cs.css" rel="stylesheet" />
    <link href="css/buttons.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
     <form id="form1" runat="server" action="home">
    <div>
        <div class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="home" > <span> <img alt="Logo" src="Images/Learn.png" height="30" /></span>TecyCybo</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="join">Register</a></li>
                        <li><a href="login">Log In</a></li>
                    </ul>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-left">
                                <li class="active"><a href="home">Home</a></li>
                                <li><a href="#">About</a></li>
                                <li><a href="#">Contact</a></li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Start<b class="caret"></b></a>
                                    <ul class="dropdown-menu">
                                        <li class="dropdown-header">Menu1</li>
                                        <li role="separator" class="divider"></li>
                                        <li><a href="#">Learn1</a></li>
                                        <li><a href="#">Learn2</a></li>
                                        <li><a href="#">Learn3</a></li>
                                        <li role="separator" class="divider"></li>
                                        <li class="dropdown-header">Menu2</li>
                                        <li role="separator" class="divider"></li>
                                        <li><a href="#">Learn2-1</a></li>
                                        <li><a href="#">Learn2-2</a></li>
                                        <li><a href="#">Learn2-3</a></li>
                                    </ul>
                                </li>
                            </ul>

                    </div>
                </div>
            </div>
        </div> 
         <!-- carousel-->
         <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                </ol>
                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="Images/1.png" alt="..." />
                        <div class="carousel-caption">
                            <h3>Iphone 6</h3>
                            <p>The New Iphone 6 Plus </p>
                            <p><a class="btn btn-primary outline" href="SignUp.aspx" role="button">Join Us</a>
                               <a class="btn btn-success outline" href="SignIn.aspx" role="button">Log In</a></p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/2.png" alt="..." />
                        <div class="carousel-caption">
                            <h3>Samsung 6</h3>
                            <p>The New samsung 6 Plus </p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="Images/3.png" alt="..." />
                        <div class="carousel-caption">
                            <h3>LG 6</h3>
                            <p>The New LG 6 Plus </p>
                        </div>
                    </div>
                </div>

                <!-- Controls -->
                <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <br/>
            <!-- carousel-->
            <div class="container center" >
                <div class="row">
                    <div class="col-lg-4">
                        <img class="img-circle" src="Images/ArrowRight.png" alt="thumb01" width="140" height="140" />
                        <h2>IPhone</h2>
                        <p>
                            A "Hello, world!"
                        </p>
                        <p><a class="btn-default" href="SignUp.aspx" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-circle" src="Images/ArrowLeft.png" alt="thumb02" width="140" height="140" />
                        <h2>Samsung</h2>
                        <p>
                            A "Hello, world!" program 
                        </p>
                        <p><a class="btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                     <div class="col-lg-4">
                        <img class="img-circle" src="Images/Sync.png" alt="thumb03" width="140" height="140" />
                        <h2>LG</h2>
                        <p>
                            A "Hello, world!" program is often used to introduce beginning 
                        </p>
                        <p><a class="btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                     <div class="col-lg-4">
                        <img class="img-circle" src="Images/ArrowRight.png" alt="thumb01" width="140" height="140" />
                        <h2>IPhone</h2>
                        <p>
                            A "Hello, world!" program is often used to introduce beginning programmers 
                        </p>
                        <p><a class="btn-default" href="SignUp.aspx" role="button">View &raquo;</a></p>
                    </div>
                    <div class="col-lg-4">
                        <img class="img-circle" src="Images/ArrowLeft.png" alt="thumb02" width="140" height="140" />
                        <h2>Samsung</h2>
                        <p>
                            A "Hello, world!" program is often used to introduce beginning programmers to a programming language. In general, 
                        </p>
                        <p><a class="btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                     <div class="col-lg-4">
                        <img class="img-circle" src="Images/Sync.png" alt="thumb03" width="140" height="140" />
                        <h2>LG</h2>
                        <p>
                            A "Hello, world!" program is often used to introduce beginning programmers to a programming language. In general, it is simple enough 
                        </p>
                        <p><a class="btn-default" href="#" role="button">View &raquo;</a></p>
                    </div>
                </div>
            </div>
            <!--Middle contents -->
            
            
            <!--Footer -->
            <hr/>
            <footer>
                <div class ="container">
                    <p class="pull-right"><a href="#">Back to top</a></p>
                    <p>&copy 2015 TechTeach.com &middot; <a href="Default.aspx">Home</a>
                        <a href="#">About</a>&middot;<a href="#">Contact</a> &middot;<a href ="#">Start</a>
                    </p>
                    </div>
            </footer>
    </div>
    </form>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
