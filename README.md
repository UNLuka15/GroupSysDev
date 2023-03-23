# Museum Customer Experience Analysis Platform

This project aims to transform the customer experience (CX) at museums by building a platform capable of analyzing customer feedback from various sources, such as Google Reviews.

## Table of Contents

1. [Overview](#overview)
2. [Installation](#installation)
3. [Usage](#usage)
4. [Code Explanation](#code-explanation)
5. [License](#license)
6. [Contact](#contact)

## Overview

This code retrieves reviews from Google Reviews for the specified place (London Science Museum) and stores them in a MySQL database. The module `sql_integration.py` connects to a MySQL database, creates a table for storing reviews, inserts the reviews, and selects all the stored reviews using SQL. The `google_places_api.py` retrieves reviews of a specified place using the Google Places API.

## Installation

### Prerequisites

- Python 3.x
- MySQL Server
- Required Python Packages: requests, mysql-connector-python

To install the required Python packages, run the following command:

```bash
pip install requests mysql-connector-python
```


## Usage
1. Update the API_KEY constant in the google_places_api.py file with your own Google Places API key.
2. Update the MySQL database credentials in the connect_to_database function in the sql_integration.py file.
3. Run the sql_integration.py file:
```
python sql_integration.py
```

This will connect to the MySQL database, create a table for storing reviews, insert the reviews, and select all the stored reviews using SQL.

