﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AUST_news.aspx.cs" Inherits="AUST_news" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
	<title>AUST News | AUST Student Management</title>
	<link rel="stylesheet" href="styles/myStyle.css">
	<style>
	body {
		background-image: url("images/BBGG.jpg");
	}
	
	button[type=submit] {
		display: inline-block;
		color: Black;
		background-color: white;
		text-align: center;
		padding: 14px 16px;
		text-decoration: none;
		min-width: 165px;
		box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
		z-index: 1;
	}
	button[type=submit]:hover {
		background-color: DeepSkyBlue;
	}
	.read-more-state {
	  display: none;
	}

	.read-more-target {
	  opacity: 0;
	  max-height: 0;
	  font-size: 0;
	  transition: .25s ease;
	}

	.read-more-state:checked ~ .read-more-wrap .read-more-target {
	  opacity: 1;
	  font-size: inherit;
	  max-height: 999em;
	}

	.read-more-state ~ .read-more-trigger:before {
	  content: 'Show more';
	}

	.read-more-state:checked ~ .read-more-trigger:before {
	  content: 'Show less';
	}

	.read-more-trigger {
	  cursor: pointer;
	  display: inline-block;
	  padding: 0 .5em;
	  color: #666;
	  font-size: .9em;
	  line-height: 2;
	  border: 1px solid #ddd;
	  border-radius: .25em;
	}
	
	.content {
		max-width:1024px;
		float: left;
		margin-left: 155px;
		margin-bottom:10px;
	}

	.news{
		background-color: white;
		width:1024px;
		max-height: 400px;
		margin-top:10px;
		float: left; 
		padding: 2%;
		border-radius: .5em;
		resize: both;
		overflow: auto;
	}
	
	</style>
</head>
<body>
	<header>
		<img src="images/aust_logo.jpg" alt="Logo" width="80px" height="80px" class="float-img2" title = "AUST Student Management">
		<h1>AUST Student Management</h1>
	</header>
	<ul>
		<li><a href="Default.aspx">Home</a></li>
		<li><a class="active" href="AUST_news.aspx">AUST News</a></li>
		<li class="dropdown">
			<a href="javascript:void(0)" class="dropbtn">Department</a>
				<div class="dropdown-content">
					<form action="dept_info.aspx" method="get">
						<button type="submit" name="dept" value= "CSE">CSE</button>					
					</form>
					<form action="#" method="get">
						<button type="submit" name="dept" value= "EEE">EEE</button>					
					</form>
					<form action="#" method="get">
						<button type="submit" name="dept" value= "IPE">IPE</button>					
					</form>
					<form action="#" method="get">
						<button type="submit" name="dept" value= "CiviL">Civil</button>					
					</form>
					<form action="#" method="get">
						<button type="submit" name="dept" value= "ME">ME</button>					
					</form>
					<form action="#" method="get">
						<button type="submit" name="dept" value= "TE">TE</button>					
					</form>
					<form action="#" method="get">
						<button type="submit" name="dept" value= "Architecture">Architecture</button>					
					</form>
					<form action="#" method="get">
						<button type="submit" name="dept" value= "BBA">BBA</button>					
					</form>
					
				</div>
		</li>
		<li><a href="academic.aspx">Academic Calendar</a></li>
		<li><a href="events.aspx">Latest Event</a></li>
		<li><a href="about.aspx">About</a></li>
		
	</ul>

    <br />
    <br />

	<div class="slideshow-container" style="margin-left:155px">
		<div class="mySlides fade">
		  <div class="numbertext">1 / 3</div>
		  <img src="images/news1.jpg" style="width:100%;height: 410px;">
		  <div class="text">AUST convocation day was held at university premises on 1/9/2018, Tuesday.</div>
		</div>
		<div class="mySlides fade">
	    	<div class="numbertext">2 / 3</div>
			<img src="images/news2.jpg" style="width:100%;height: 410px;">
			<div class="text">Admission for Spring 2018 will be held in February.</div>
		</div>
		<div class="mySlides fade">
			<div class="numbertext">3 / 3</div>
			<img src="images/news3.jpg" style="width:100%;height: 410px;">
			<div class="text">Fall 2017 semester final exam dates has been given.</div>
		</div>

		</div>
		<br>
		<div style="text-align:center">
			<span class="dot"></span> 
			<span class="dot"></span> 
			<span class="dot"></span> 
		</div>
		
		
		
		<div class="content">
			<div class="news">
				  <input type="checkbox" class="read-more-state" id="post-1" />
				  
				  <h3 style="margin-left:0px; text-align:center;">Intra AUST programming contest held succesfully</h3>
				  <img src="images/news6.jpg" alt="" style="display:block; margin-left:auto; margin-right:auto;" />

				  <p class="read-more-wrap">Lorem Ipsum is simply dummy text of the printing and  <span class="read-more-target">typesetting 
				  industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a 
				  galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap 
				  into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset 
				  sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including 
				  versions of Lorem Ipsum.</span></p>

				  <label for="post-1" class="read-more-trigger"></label>
			</div>
			
			<div class="news">
				  <input type="checkbox" class="read-more-state" id="post-2" />
				  
				  <h3 style="margin-left:0px; text-align:center;">The cricket tournament of cse department was a mess</h3>
				  <img src= "images/news7.jpg" alt =""  style="height: 212px;width:300px;display:block; margin-left:auto; margin-right:auto;" />

				  <p class="read-more-wrap">Lorem Ipsum is simply dummy text of the printing and  <span class="read-more-target">typesetting 
				  industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a 
				  galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap 
				  into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset 
				  sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including 
				  versions of Lorem Ipsum.</span></p>

				  <label for="post-2" class="read-more-trigger"></label>
			</div>
			
			<div class="news">
				  <input type="checkbox" class="read-more-state" id="post-3" />
				  
				  <h3 style="margin-left:0px; text-align:center;">The ownership of AUST canteen is changed</h3>
				  <img src="images/news5.jpg" alt="" style="display:block; margin-left:auto; margin-right:auto;" />

				  <p class="read-more-wrap">Lorem Ipsum is simply dummy text of the printing and  <span class="read-more-target">typesetting 
				  industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a 
				  galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap 
				  into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset 
				  sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including 
				  versions of Lorem Ipsum.</span></p>

				  <label for="post-3" class="read-more-trigger"></label>
			</div>
			
			
		</div>
		
		
		<script src="myScriptNews.js"></script>
			
	</body>
</html>
