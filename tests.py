"""
tests.py
========
Various testing functions of the application
--------------------------------------------
"""
# Import Modules
import os
import sqlite3
import main
from unittest import TestCase, mock
from utils.audio_conversions import audio_to_text, record_audio, text_to_audio
from utils.db import db_clip, create_db, convert_to_binary_data, insert_blob
from utils.wolfram_alpha import request_wolfram_alpha_api
from utils.play import play


def test_request_wolfram_alpha_api():
    """
    Test we can return the correct response from the
    WolframAlpha API following a question

    Function tested: request_wolfram_alpha_api

    Module: wolfram_alpha.py
    """
    # Test question for WolframAlpha API
    question = "What is the captial of France"
    # Expected output of question
    expected = "paris"
    # Did we get back our expected answer
    assert(expected in request_wolfram_alpha_api(question).lower())


def test_request_wolfram_alpha_api_no_valid_input():
    """
    Test WolframAlpha API returns consistent response
    if there is invalid input.

    Function tested: request_wolfram_alpha_api

    Module: wolfram_alpha.py
    """
    # Random character input for WolframAlpha API
    question = "abcdef"
    # Expected output of invalid input
    expected = ("Alexa did not understand your input. "
                "Please try again")
    # Did we get back our expected answer
    assert(expected in request_wolfram_alpha_api(question))


def test_create_db():
    """
    Test that we can create a new database object

    Function tested: create_db

    Module: db.py
    """
    # Call our function to create our test database
    create_db("test")
    # Connect to our test database
    connection = sqlite3.connect("test.db")
    # Check we can connect to the database we've just created
    assert connection
    # Remove our test database once we've finished
    os.remove("test.db")


def test_db_clip():
    """
    Test that we make the correct database calls
    when choosing a suitable clip with a mock cursor

    Function tested: db_clip

    Module: db.py
    """
    # An example description
    description = "loud noise"
    # Assign our mock cursor
    cur = mock.MagicMock()
    # Call our function with our description and mock cursor
    db_clip(description, cur)
    # Do we execute the query
    cur.execute.assert_called()
    # Do we fetch our record
    cur.fetchone.assert_called()


def test_db_clip_no_valid_input():
    """
    Test we handle no valid input and return None
    for correct future processing

    Function tested: db_clip

    Module: db.py
    """
    # Connect to our database
    con = sqlite3.connect('alexa.db')
    # Create our cursor object
    cur = con.cursor()
    # Set our description to nothing valid
    description = None
    # Attempt to find our relevant clip
    name, blob = db_clip(description, cur)
    # As the input wasn't valid ensure we set
    # these null fields
    assert name is None
    assert blob is None


def test_convert_to_binary_data():
    """
    Test we successfully convert our file to binary data

    Test clip found contains 'testing' speech

    Function tested: convert_to_binary_data

    Module: db.py
    """
    # Assign our filename to test
    filename = ("sounds/test_clip.wav")
    # We know the size of the test clip
    known_size = 218734
    # Call our function with the filename and save
    # our return values
    blobData, test_size = convert_to_binary_data(filename)
    # Validate our known size is the same as our converted file size
    assert known_size == test_size


def test_record_audio():
    """
    Test we save our audio file in the specified location

    Function tested: record_audio

    Module: audio_conversions.py
    """
    # Save our expected filename
    expected = "sounds/recorded.wav"
    # Assert we return our correct filename
    assert(expected in record_audio())


def test_audio_to_text_play_off():
    """
    Test audio to text conversion, ensuring the play flag
    is set off appropriately.

    User input in audio file
        "What is the distance between London and New York?"

    Function tested: audio_to_text

    Module: audio_conversions.py
    """
    # Expected user audio input converted to text
    expected_text_output = "What is the distance between London and New York?"
    # We don't expect to set the play flag on for a question so
    # it should be off
    expected_play_flag = 0
    # Call our function and save our return values
    (test_text_output,
     test_play_flag) = audio_to_text("sounds/test_audio_no_play.wav")
    # Ensure we haven't set the play flag and have returned the correct text
    assert test_text_output == expected_text_output
    assert test_play_flag == expected_play_flag


def test_audio_to_text_play_on():
    """
    Test audio to text conversion, ensuring the play flag
    is set on appropriately.

    User input in audio_test_play.wav audio file
        "Play door slam"

    Function tested: audio_to_text

    Module: audio_conversions.py
    """
    # Expected stripped input conversion
    expected_text_output = "door slam"
    # We expect to set the play flag on following a play command
    expected_play_flag = 1
    # Ensure we set the play flag and have returned the
    # correct stripped text for processing
    assert expected_text_output, expected_play_flag \
           in audio_to_text("audio_test_play.wav")


def test_audio_to_text_no_input():
    """
    Test we handle no valid user input and if so
    set our text output to a null field.

    No user input in file.

    Function tested: audio_to_text

    Module: audio_conversions.py
    """
    # Call our function and assign return values
    text_output, play_flag = audio_to_text("sounds/test_blank.wav")
    # Ensure as the input wasn't valid we set the
    # field to null
    assert text_output is None


def test_text_to_audio():
    """
    Test we recieve an OK status code following
    our call to the Microsoft Azure API to convert
    our text to audio

    Function tested: text_to_audio

    Module: audio_conversions.py
    """
    # Give our text to convert to audio
    text = "testing"
    # Call our function using our text save the return code
    return_code = text_to_audio(text)
    # Was the return code ok
    assert (return_code == 200)


def test_main_imports():
    """
    Test main imports are successfully implemented

    Module: main.py
    """
    # Gather our imports from main
    test_sqlite3 = main.sqlite3
    test_threading = main.threading
    test_logging = main.logging
    # Assert the boolean value is true, hence
    # imported correctly
    assert bool(test_sqlite3) is True
    assert bool(test_threading) is True
    assert bool(test_logging) is True


# Utilise TestCase class which provides the ability for our tests
class logging_exception_tests(TestCase):

    def test_play_blob(self):
        """
        Test appropriate messages are logged successfully

        Finding 'door slam' clip from database to play

        Function tested: play

        Module: play.py
        """
        # Connect to the SQLite database file
        con = sqlite3.connect('alexa.db')
        # Create our cursor object to invoke our methods
        cur = con.cursor()
        # Find our relevant clip using the user input
        name, blob = db_clip('door slam', cur)
        # Play the clip we've found
        with self.assertLogs() as captured:
            play(blob)
        self.assertEqual(len(captured.records), 1)
        self.assertEqual(captured.records[0].getMessage(),
                         "Playing byte type object")

    def test_play(self):
        """
        Test FileNotFoundError exception is raised appropriately
        when file given isn't found

        Function tested: play

        Module: play.py
        """
        # Verify FileNotFoundError exception is raised
        self.assertRaises(FileNotFoundError, play, "File_not_found.wav")

    def test_audio_to_text(self):
        """
        Test appropriate messages are logged succesfully

        User input in audio_test_play.wav audio file
            "Play door slam"

        Function tested: audio_to_text

        Module: audio_conversions.py
        """
        # Capture the log output of each message as a list of strings
        with self.assertLogs() as captured:
            audio_to_text("sounds/test_audio_play.wav")
        # Check we have the expected number of log records
        self.assertEqual(len(captured.records), 2)
        # And the message that we expect
        self.assertEqual(captured.records[0].getMessage(),
                         "Converting user input to text")
        self.assertEqual(captured.records[1].getMessage(),
                         "user input: Play door slam.")

    def test_insert_blob_logging(self):
        """
        Test approrpriate messages are logged succesfully

        Function tested: insert_blob

        Module: db.py
        """
        # Let's clean up from any previous tests
        # Connect to the SQLite database
        sqliteConnection = sqlite3.connect("alexa.db")
        # Create our cursor object to invoke our methods
        cur = sqliteConnection.cursor()
        # Format for removing data into our table
        sqlite_remove_blob_query = """ DELETE FROM clips
                                       WHERE clip = "empty" """
        # Remove our test data
        cur.execute(sqlite_remove_blob_query)
        # Save our database changes
        sqliteConnection.commit()
        # Close our cursor connection
        cur.close()

        # Assign out given values to test
        clip = "empty"
        content_file = "sounds/test_clip.wav"
        loud = False
        music = False
        description = "test"

        # Capture the log output of each message as a list of strings
        with self.assertLogs() as captured:
            insert_blob(clip, content_file, loud, music, description)
        # Check we have the expected number of log records
        self.assertEqual(len(captured.records), 2)
        # And the message that we expect
        self.assertEqual(captured.records[0].getMessage(),
                         "Clips successfully inserted into table")
        self.assertEqual(captured.records[1].getMessage(),
                         "The sqlite connection is closed")

        # Attempt to insert the same blob again and ensure data can
        # only be unique
        with self.assertLogs() as captured:
            insert_blob(clip, content_file, loud, music, description)
        # Check that we did not insert any clips into the table
        # and handle any sqlite3.Error exceptions
        self.assertNotEqual(captured.records[0].getMessage(),
                            "Clips successfully inserted into table")
