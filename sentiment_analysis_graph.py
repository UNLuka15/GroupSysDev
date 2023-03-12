# Good for understanding purpose of the reviews we are doing -> https://medium.com/artefact-engineering-and-data-science/customer-reviews-use-nlp-to-gain-insights-from-your-data-4629519b518e

import mysql.connector
from nltk.sentiment import SentimentIntensityAnalyzer
import matplotlib.pyplot as plt
from datetime import datetime


def connect_to_database(host, user, password, database):
    connection = mysql.connector.connect(host=host, user=user, password=password, database=database)
    return connection


def get_reviews_text_date_from_db(connection):
    cursor = connection.cursor()

    cursor.execute("SELECT review_text, review_date FROM google_reviews")
    reviews = []
    for text, date in cursor:
        reviews.append({'text': text, 'date': date})

    return reviews


def group_reviews_by_year(reviews):
    sia = SentimentIntensityAnalyzer()
    sentiment_by_year = {}
    for review in reviews:
        text_str = str(review['text'])
        date_str = str(review['date'])
        date = datetime.strptime(date_str, '%Y-%m-%d')
        year = date.year
        sentiment_dict = sia.polarity_scores(text_str)
        compound_sentiment = sentiment_dict['compound']
        if year in sentiment_by_year:
            sentiment_by_year[year].append(compound_sentiment)
        else:
            sentiment_by_year[year] = [compound_sentiment]
    return sentiment_by_year


def get_avg_sentiment_by_year(year_list, sentiment_by_year):
    avg_sentiment_by_year = [sum(sentiment_by_year.get(year, [0]))/len(sentiment_by_year.get(year, [0])) for year in year_list]
    return avg_sentiment_by_year


def plot_sentiment(year_list, avg_sentiment_by_year):
    plt.plot(year_list, avg_sentiment_by_year)
    plt.title("Average Sentiment London Science Museum")
    plt.xlabel("Year")
    plt.ylabel("Average Yearly Sentiment Score")
    plt.ylim(-0.5, 1)
    plt.xticks(year_list, [str(year) for year in year_list])
    plt.show()


if __name__ == '__main__':
    # Connect to the MySQL database
    host = 'localhost'
    user = 'root'
    password = '*'
    database = 'reviewsdb'
    connection = connect_to_database(host, user, password, database)

    # Get reviews from the database
    reviews = get_reviews_text_date_from_db(connection)

    # Group the reviews by year
    sentiment_by_year = group_reviews_by_year(reviews)

    # Calculate the average sentiment by year
    year_list = list(range(2020, 2024))
    avg_sentiment_by_year = get_avg_sentiment_by_year(year_list, sentiment_by_year)

    # Plot the line chart
    plot_sentiment(year_list, avg_sentiment_by_year)