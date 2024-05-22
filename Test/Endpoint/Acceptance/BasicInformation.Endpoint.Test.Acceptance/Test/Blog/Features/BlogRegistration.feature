@Acceptance
Feature: Blog Registration
	As a blog manager
	I want to have a collection of my blogs
	So that I always have accurate informaion about different blogs topics

Scenario: Register a new blog
	Given I want to register following blog
		| Title | Description               |
		| Space | all about space discoveries |
	When I try to register the blog
	Then the blog should be registered