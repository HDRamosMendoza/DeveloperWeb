const path = require("path");

module.exports = {
    entry: "./src/alumnos.js",
    output: {
        filename: "alumnos.js",
        path: path.resolve(__diname, "dist")
    }
}