---
layout: page
title: My Page
---
# FurniGo.DataMapper
Project part of the FurniGo application. It is responsible for mapping the data from the database to the applications dependant on it.
At the moment, the three following contexts are supported:
- IAM (Identity and Access Management)
- App (Main application involved in management of orders and tracking of them)
- Social Network (Social network for the application)

## Getting Started
This follows a Domain Driven Design (DDD) approach. Aside from the contexts mentioned before, also a Shared one is present.
Each domain contains:
- Domain
	- Models
	- Repositories
- Infrastucture
	- Repositories
	- Configuration (for Shared context only)
- Mapping
	- Base object (from database) to domain specific object (and vice versa)
	- DTO (Data Transfer Object) to domain specific object (and vice versa)
- Resources
	- DTO definitions

