import requests
import json
import mysql.connector
from datetime import datetime

# Constants
API_KEY = ''
PLACE_ID = 'ChIJP9oAE0MFdkgR3iKGFKZO1SE'
URL = f'https://maps.googleapis.com/maps/api/place/details/json?place_id={PLACE_ID}&fields=name,rating,review&key={API_KEY}'

#TODO - Anonymise data in DB i.e. remove name

def get_reviews(url):
    """
    Retrieves the reviews of a place from the Google Places API.

    Args:
        url (str): The URL to send the request to.

    Returns:
        dict: A dictionary containing the name, rating, and reviews of the place.
    """
    # Send the request to the API
    response = requests.get(url)

    # If the request was successful, extract the relevant information
    if response.status_code == 200:
        data = json.loads(response.content)
        name = data['result']['name']
        rating = data['result']['rating']
        reviews = data['result']['reviews']

        # Return a dictionary containing the extracted information
        return {'name': name, 'rating': rating, 'reviews': reviews}
    else:
        # If the request failed, raise an exception
        raise Exception(f'Request failed with status code {response.status_code}')


def create_reviews_table(connection):
    """
    Creates a table for storing the reviews of a place in a MySQL database.

    Args:
        connection (mysql.connector.connection.MySQLConnection): A connection to a MySQL database.
    """
    # Create a cursor to execute SQL statements
    cursor = connection.cursor()

    # Create the reviews table if it doesn't already exist
    cursor.execute("CREATE TABLE IF NOT EXISTS google_reviews ("
                   "id INT AUTO_INCREMENT PRIMARY KEY,"
                   "place_name VARCHAR(255),"
                   "author_name VARCHAR(255),"
                   "review_text TEXT,"
                   "rating FLOAT,"
                   "review_date DATE"
                   ")")

    # Commit the changes to the database
    connection.commit()


def insert_reviews(data, connection):
    """
    Inserts the reviews of a place into a MySQL database.

    Args:
        data (dict): A dictionary containing the name, rating, and reviews of the place.
        connection (mysql.connector.connection.MySQLConnection): A connection to a MySQL database.
    """
    # Extract the reviews from the data dictionary
    reviews = data['reviews']

    # Create a cursor to execute SQL statements
    cursor = connection.cursor()

    # Loop through the reviews and insert them into the database
    for review in reviews:
        author_name = review['author_name']
        text = review['text']
        rating = review['rating']
        date = datetime.fromtimestamp(review['time']) # convert time from unix timestamp

        # Insert the review into the database but don't if it already exists
        cursor.execute("INSERT INTO google_reviews (place_name, author_name, review_text, rating, review_date) VALUES (%s, %s, %s, %s, %s)",
                       (data['name'], author_name, text, rating, date))

    # Commit the changes to the database
    connection.commit()

def select_all_from_table(connection):
    cursor = connection.cursor()

    cursor.execute("SELECT * FROM google_reviews")
    for row in cursor:
        print(row)

if __name__ == '__main__':
    # Connect to the MySQL database
    host = 'localhost'
    user = 'root'
    password = '*'
    database = 'reviewsdb'
    connection = mysql.connector.connect(host=host, user=user, password=password, database=database)

    # Create the reviews table
    create_reviews_table(connection)

    # Get the reviews from the API
    data = get_reviews(URL)

    # Insert the reviews into the database
    #insert_reviews(data, connection)

    # Select all reviews from the table
    select_all_from_table(connection)

    # Close the database connection
    connection.close()