module.exports = {
    extends: ["./node_modules/@commitlint/config-conventional"],
    parserPreset: {
      parserOpts: {
        headerPattern: /^(\w*)\/SPPP-(\w*): (.*)$/,
        headerCorrespondence: ["type", "scope", "subject"],
      },
    },
    rules: {
      "type-enum": [2, "always", ["feat", "fix", "hot", "chore", "doc"]],
      "header-min-length": [2, "always", 10],
      "header-max-length": [2, "always", 70],
      "body-max-line-length": [2, "always", 80],
      "subject-full-stop": [2, "always", "."],
      "subject-case": [
        2,
        "never",
        ["lower-case", "upper-case"],
    ],
      "body-case": [
        2,
        "never",
        ["lower-case", "upper-case"],
      ],
    },
  }