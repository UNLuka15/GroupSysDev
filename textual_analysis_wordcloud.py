import mysql.connector
from wordcloud import WordCloud
import matplotlib.pyplot as plt


def connect_to_database(host, user, password, database):
    """Connect to a MySQL database and return a connection object."""
    connection = mysql.connector.connect(host=host, user=user, password=password, database=database)
    return connection


def get_reviews_from_db(connection):
    """Retrieve review text and date from a MySQL database and return a list of dictionaries."""
    cursor = connection.cursor()
    cursor.execute("SELECT review_text, review_date FROM google_reviews")
    reviews = [{'text': text, 'date': date} for text, date in cursor]
    return reviews


def generate_word_cloud(text):
    """Generate a word cloud from the given text string and return the WordCloud object."""
    wordcloud = WordCloud(width=800, height=800, background_color='white', min_font_size=10).generate(text)
    return wordcloud


def display_word_cloud(wordcloud, title):
    """Display the given word cloud using matplotlib, with the given title."""
    plt.figure(figsize=(8,8))
    plt.imshow(wordcloud)
    plt.axis('off')
    plt.title(title)
    plt.show()


if __name__ == '__main__':
    # Connect to the MySQL database
    host = 'localhost'
    user = 'root'
    password = '*'
    database = 'reviewsdb'
    connection = connect_to_database(host, user, password, database)
    
    # Get reviews from the database
    reviews = get_reviews_from_db(connection)
    review_text = []
    for text in reviews: 
        text_str = str(text['text'])
        review_text.append(text_str)
    
    # Create wordcount for all reviews, all years
    wordcloud = WordCloud(max_words=50, background_color='white').generate(' '.join(review_text))
    display_word_cloud(wordcloud, title='Overall Museum Reviews')
    
    # Create and display a word cloud for each year
    for year in range(2020, 2024):
        text_str = ""
        for review in reviews:
            if review['date'].year == year:
                text_str += str(review['text'])
        wordcloud = WordCloud(max_words=50, background_color='white').generate(text_str)
        display_word_cloud(wordcloud, title=str(year))
