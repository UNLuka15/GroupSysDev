
# Interesting link on using text mining and matplotlib - e.g. how many reviews per month, distribution of rating, high-frequency words
# https://www.analyticsvidhya.com/blog/2022/10/using-text-mining-on-reviews-data-to-generate-business-insights/

# Exact project on British Museum
# https://museum-id.com/invisible-insights-learning-from-tripadvisor-reviews/

# Could we get reviews from social media - common place?

import mysql.connector
from nltk.sentiment import SentimentIntensityAnalyzer
import matplotlib.pyplot as plt

def get_rating_from_db(connection):
    cursor = connection.cursor()

    cursor.execute("SELECT rating FROM google_reviews")
    for row in cursor:
        print(row)

def get_reviews_text_from_db(connection):
    cursor = connection.cursor()

    cursor.execute("SELECT review_text FROM google_reviews")
    review_text = []
    for text in cursor:
        review_text.append(text)
    
    return review_text


if __name__ == '__main__':

    # Connect to the MySQL database
    host = 'localhost'
    user = 'root'
    password = '*'
    database = 'reviewsdb'
    connection = mysql.connector.connect(host=host, user=user, password=password, database=database)

    # Instantiate the sentiment analyzer
    sia = SentimentIntensityAnalyzer()

    # get_rating_from_db(connection)
    review_text_list = get_reviews_text_from_db(connection)

    for text in review_text_list: 
        # Convert tuple element to string
        text_str = str(text)

        # Analyze the sentiment of the text
        sentiment_dict = sia.polarity_scores(text_str)

        # Print the sentiment scores
        print("=============================")
        print("Overall sentiment dictionary is: ", sentiment_dict)
        print(sentiment_dict['neg']*100, "% Negative")
        print(sentiment_dict['neu']*100, "% Neutral")
        print(sentiment_dict['pos']*100, "% Positive")

        print("Sentence Overall Rated As", end = " ")

        # decide sentiment as positive, negative and neutral
        if sentiment_dict['compound'] >= 0.05 :
            print("Positive")
    
        elif sentiment_dict['compound'] <= - 0.05 :
            print("Negative")
    
        else :
            print("Neutral")