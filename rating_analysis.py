import mysql.connector
import matplotlib.pyplot as plt
from datetime import datetime


def connect_to_database(host, user, password, database):
    connection = mysql.connector.connect(host=host, user=user, password=password, database=database)
    return connection


def get_reviews_rating_date_from_db(connection):
    cursor = connection.cursor()

    cursor.execute("SELECT rating, review_date FROM google_reviews")
    reviews = []
    for rating, date in cursor:
        reviews.append({'rating': rating, 'date': date})

    return reviews

def group_ratings_by_year(reviews):
    ratings_by_year = {}
    for review in reviews:
        rating = review['rating']
        date = review['date']
        year = date.year
        if year in ratings_by_year:
            ratings_by_year[year].append(rating)
        else:
            ratings_by_year[year] = [rating]
    return ratings_by_year


def get_review_count_by_year(year_list, reviews):
    review_count_by_year = []
    for year in year_list:
        count = sum(1 for review in reviews if review['date'].year == year)
        review_count_by_year.append(count)
    return review_count_by_year

def get_avg_rating_by_year(year_list, rating_by_year):
    avg_rating_by_year = []
    for year in year_list:
        if year in rating_by_year:
            avg_rating = sum(rating_by_year[year])/len(rating_by_year[year])
            avg_rating_by_year.append(avg_rating)
        else:
            avg_rating_by_year.append(0)
    return avg_rating_by_year

def plot_bar_average_rating(year_list, avg_rating_by_year):
    plt.bar(year_list, avg_rating_by_year)
    plt.title("Average Rating London Science Museum")
    plt.xlabel("Year")
    plt.ylabel("Average Yearly Rating Score")
    plt.ylim(0, 5)
    plt.xticks(year_list, [str(year) for year in year_list])
    plt.show()

def plot_line_review_count(year_list, review_count_by_year):
    plt.plot(year_list, review_count_by_year)
    plt.title("Number of Reviews per Year")
    plt.xlabel("Year")
    plt.ylabel("Number of Reviews")
    plt.xticks(year_list, [str(year) for year in year_list])
    plt.show()

if __name__ == '__main__':
    # Connect to the MySQL database
    host = 'localhost'
    user = 'root'
    password = '*'
    database = 'reviewsdb'
    connection = connect_to_database(host, user, password, database)

    # Get the reviews from the database
    reviews = get_reviews_rating_date_from_db(connection)

    # Group the ratings by year
    rating_by_year = group_ratings_by_year(reviews)

    # Calculate the average rating by year
    year_list = list(range(2020, 2024))
    avg_rating_by_year = get_avg_rating_by_year(year_list, rating_by_year)

    # Plot the bar chart of average rating per year
    plot_bar_average_rating(year_list, avg_rating_by_year)

    # Calculate the review count by year
    review_count_by_year = get_review_count_by_year(year_list, reviews)

    # Plot the line graph of number of reviews per year to determine sample size
    plot_line_review_count(year_list, review_count_by_year)
