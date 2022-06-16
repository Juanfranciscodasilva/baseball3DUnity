module.exports = {
  env: {
    es6: true,
    node: true,
  },
  extends: [
    'eslint:recommended',
    'google',
  ],
  rules: {
    'quotes': ['error', 'single'],
    'arrow-parens': ['error', 'as-needed'],
    'max-len': 'off',
    'require-jsdoc': 0,
  },
};
