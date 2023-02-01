// An example of a button as a React component. When it is pressed, the text will change to 'You have successfully logged in.'.

'use strict';

const e = React.createElement;

class LoginButton extends React.Component {
  constructor(props) {
    super(props);
    this.state = { loggedIn: false };
  }

  render() {
    if (this.state.loggedIn) {
      return 'You have successfully logged in.';
    }

    return e(
      'button',
      { onClick: () => this.setState({ loggedIn: true }) },
      'Login'
    );
  } 
}

const domContainer = document.querySelector('#login_button_container');
const root = ReactDOM.createRoot(domContainer);
root.render(e(LoginButton));