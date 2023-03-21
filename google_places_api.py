"""
google_places_api.py
================
Retrieves reviews of a specified place using the Google Places API
----------------------------------------------------------
"""
# Import Standard Library Modules
import requests
import json
from datetime import datetime

# Constants
API_KEY = ''
PLACE_ID = 'ChIJP9oAE0MFdkgR3iKGFKZO1SE' # London Science Museum 
URL = f'https://maps.googleapis.com/maps/api/place/details/json?place_id={PLACE_ID}&fields=name,rating,review&key={API_KEY}'

#TODO - Anonymise data in DB i.e. remove name, can we get a date field to satisfy requirement

def get_google_reviews(url):
    """
    Retrieves the reviews of a place from the Google Places API.

    Parameters:
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