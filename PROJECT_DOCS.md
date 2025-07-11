

Overview
===========================================
Curated blog posts and articles from across the internet that I find worthy of sharing.


How It Works
===========================================
I link out to a blog post or articles that I like along with some added commentary. Users 
are able to submit links for consideration. Users sign in to be able to provide their own 
responses to the links shared on the site.


Front Page

+-------------------------------------------+
| [Website Title]        [Login] [Submit]   |
+-------------------------------------------+

1. 🔗 Why are there no good dinosaur films?
      (briannazigler.substack.com)
    💬 “A dinosaur film is a perfect mix of horror and excitement...”
    👍 55 points | 👤 you | 💬 12 comments

-------------------------------------------

2. 🔗 NYC Subway Simulator and Route Designer
      (buildmytransit.nyc)
    💬 “A fun and strangely satisfying planning tool for transit nerds...”
    👍 133 points | 👤 HeavenFox | 💬 13 comments

-------------------------------------------


Comment Page

+-------------------------------------------+
| [Website Title]         [Back to Front]   |
+-------------------------------------------+

🔗 Why are there no good dinosaur films?
   (briannazigler.substack.com)

💬 My Commentary:
“A dinosaur film is a perfect mix of horror and excitement to catch
my interest. I will skip lunch tomorrow to save the $20 to go see it.”

------------------------------------------------
💬 Comments
------------------------------------------------

👤 fremden:  
"I agree — Jurassic Park still hasn’t been topped."

👤 mediahound:  
"Check out Prehistoric Planet. Not quite a film but hits the spot."

[Add Comment Box Here]

------------------------------------------------






Development
===========================================
* docker-compose.yml starts pgadmin, enabling an insight into the production or development databases.
* development database is CompanyA on AWS, production is called newsite


Deployment
=========================================== 
* The site is dockerized and deployed to Elastic Container Registry for deployment on App Runner
* The database is postgres and hosted on AWS free tier. 
* The production datbase is newsite, the devlopment database is CompanyA
* Migrations are configured to run on app startup



Database
===========================================
* There are two databases, development called CompanyA, and the production called newsite.
* When ready to deploy, the connection string needs modified.
* The field and column "bool Active" indicates a record is active, ie deleted.


Source Code
===========================================
* github.com/blackmathx/newsite
