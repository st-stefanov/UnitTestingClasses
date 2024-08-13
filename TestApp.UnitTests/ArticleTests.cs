using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        this._article = new Article();
    }
    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articleData =
        {
            "Article Content Author",
            "Article2 Content2 Author2",
            "Article3 Content3 Author3",
        };

        // Act
        Article result = this._article.AddArticles(articleData);
        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Teodor",
                    Content = "Some Content",
                    Title = "Beginners Coding"
                },
                new Article()
                {
                    Author = "Ivan",
                    Content = "Other Content",
                    Title = "A brief overview of Architecture"
                },
            }
        };

        string expected = $"A brief overview of Architecture - Other Content: Ivan{Environment.NewLine}Beginners Coding - Some Content: Teodor";


        string actual = this._article.GetArticleList(inputArticle, "title");

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Teodor",
                    Content = "Some Content",
                    Title = "Beginners Coding"
                },
                new Article()
                {
                    Author = "Ivan",
                    Content = "Other Content",
                    Title = "A brief overview of Architecture"
                },
            }
        };  

        string actual = this._article.GetArticleList(inputArticle, "not-criteria");

        Assert.AreEqual(string.Empty, actual);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenArticleHasNoArticlesInItsList()
    {
        Article inputArticle = new Article();
        
           
        

        string actual = this._article.GetArticleList(inputArticle, "title");

        Assert.AreEqual(string.Empty, actual);
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByContent()
    {
        Article inputArticle = new Article()
        {
            ArticleList = new()
            {
                new Article()
                {
                    Author = "Teodor",
                    Content = "Some Content",
                    Title = "Beginners Coding"
                },
                new Article()
                {
                    Author = "Ivan",
                    Content = "Other Content",
                    Title = "A brief overview of Architecture"
                },
            }
        };

        string expected = $"A brief overview of Architecture - Other Content: Ivan{Environment.NewLine}Beginners Coding - Some Content: Teodor";

        string actual = this._article.GetArticleList(inputArticle, "not-criteria");

        Assert.AreEqual(string.Empty, actual);
    }
}
