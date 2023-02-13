// Location of backend
// the url of the backend server
export const server =
  process.env.REACT_APP_ENV === "production"
    ? "/UpTestReact" //    ? "/Discom.UPDash"
    : process.env.REACT_APP_ENV === "kestrel"
    ? ""
    : // "https://localhost:7204";    // lokal gegen VS im https mode. Lange nicht mehr getestet
      // "http://localhost:5205"; // lokal gegen VS
      "http://localhost:5117"; // lokal gegen VS
//  "http://localhost:5000";    // lokal gegen Kestrel
//   "http://localhost/UpTestReact"; // lokal mit IIS im testbetrieb
// "http://192.168.178.66/UpTestReact"; // zu Hause mit Telefon am IIS

export const webAPIUrl = `${server}/api`;

export const webBASEUrl =
  process.env.REACT_APP_ENV === "production"
    ? "/UpDash" //    ? "/Discom.UpDash"
    : process.env.REACT_APP_ENV === "kestrel"
    ? ""
    : "";

export const navBaseName =
  process.env.REACT_APP_ENV === "production"
    ? "/UpTestReact"
    : process.env.REACT_APP_ENV === "kestrel"
    ? ""
    : "";

export const authSettings = {
  domain: "your-tenant-id.auth0.com",
  client_id: "your-client-id",
  redirect_uri: window.location.origin + "/signin-callback",
  scope: "openid profile QandAAPI email",
  audience: "https://qanda",
};
