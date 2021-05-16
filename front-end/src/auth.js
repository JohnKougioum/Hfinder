import axios from "axios";

// axios.defaults.withCredentials = true;

class Auth {
  constructor() {
    this.authenticated = false;
  }
  isAuthenticated() {
    const accessToken = localStorage.getItem("authToken");
    
    if (!accessToken) return (this.authenticated = false);

    if (accessToken){
        return (this.authenticated = true);
    }
  }
}

export default new Auth();
