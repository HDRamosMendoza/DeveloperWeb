const path = require("path");

module.exports = {
    entry: "./src/alumno.js",
    output: {
        filename: "alumno.js",
        path: path.resolve(__dirname, "dist")
    }
}