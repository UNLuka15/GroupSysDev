const domContainer = document.querySelector('#root');
const root = ReactDOM.createRoot(domContainer);
const _name = "Finley";
root.render(<h1>Hello, {_name}!</h1>);