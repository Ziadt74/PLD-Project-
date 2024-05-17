
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_MINUSMINUS           =  4, // '--'
        SYMBOL_EXCLAMEQ             =  5, // '!='
        SYMBOL_PERCENT              =  6, // '%'
        SYMBOL_LPAREN               =  7, // '('
        SYMBOL_RPAREN               =  8, // ')'
        SYMBOL_TIMES                =  9, // '*'
        SYMBOL_TIMESTIMES           = 10, // '**'
        SYMBOL_COMMA                = 11, // ','
        SYMBOL_DIV                  = 12, // '/'
        SYMBOL_COLON                = 13, // ':'
        SYMBOL_QUESTION             = 14, // '?'
        SYMBOL_LBRACKET             = 15, // '['
        SYMBOL_RBRACKET             = 16, // ']'
        SYMBOL_LBRACE               = 17, // '{'
        SYMBOL_RBRACE               = 18, // '}'
        SYMBOL_PLUS                 = 19, // '+'
        SYMBOL_PLUSPLUS             = 20, // '++'
        SYMBOL_LT                   = 21, // '<'
        SYMBOL_LTLT                 = 22, // '<<'
        SYMBOL_LTEQ                 = 23, // '<='
        SYMBOL_EQ                   = 24, // '='
        SYMBOL_EQEQ                 = 25, // '=='
        SYMBOL_GT                   = 26, // '>'
        SYMBOL_GTEQ                 = 27, // '>='
        SYMBOL_GTGT                 = 28, // '>>'
        SYMBOL_BITWISEOPERATOR      = 29, // BitwiseOperator
        SYMBOL_BOOLEAN              = 30, // Boolean
        SYMBOL_BREAK                = 31, // break
        SYMBOL_CASE                 = 32, // case
        SYMBOL_DICT                 = 33, // dict
        SYMBOL_DIGIT                = 34, // Digit
        SYMBOL_DO                   = 35, // do
        SYMBOL_ELSE                 = 36, // else
        SYMBOL_END                  = 37, // End
        SYMBOL_FOR                  = 38, // for
        SYMBOL_IDENTIFIER           = 39, // Identifier
        SYMBOL_IF                   = 40, // if
        SYMBOL_IN                   = 41, // in
        SYMBOL_LIST                 = 42, // list
        SYMBOL_RANGE                = 43, // range
        SYMBOL_START                = 44, // Start
        SYMBOL_STRING               = 45, // String
        SYMBOL_SWITCH               = 46, // switch
        SYMBOL_WHILE                = 47, // while
        SYMBOL_CASE_LIST            = 48, // <case_list>
        SYMBOL_CONCEPT              = 49, // <concept>
        SYMBOL_CONDITION            = 50, // <condition>
        SYMBOL_DICT2                = 51, // <dict>
        SYMBOL_DO_WHILE             = 52, // <do_while>
        SYMBOL_ELIF_STMT            = 53, // <elif_stmt>
        SYMBOL_ELSE_STMT            = 54, // <else_stmt>
        SYMBOL_EXPO                 = 55, // <expo>
        SYMBOL_EXPR                 = 56, // <expr>
        SYMBOL_EXPRESSION           = 57, // <Expression>
        SYMBOL_FACTOR               = 58, // <factor>
        SYMBOL_FOR_STMT             = 59, // <for_stmt>
        SYMBOL_ID                   = 60, // <id>
        SYMBOL_IF_STMT              = 61, // <if_stmt>
        SYMBOL_INSIDE_DICT          = 62, // <inside_dict>
        SYMBOL_INSIDE_LIST          = 63, // <inside_list>
        SYMBOL_KEY                  = 64, // <key>
        SYMBOL_LIST2                = 65, // <list>
        SYMBOL_OP                   = 66, // <op>
        SYMBOL_PROGRAM              = 67, // <program>
        SYMBOL_STEP                 = 68, // <step>
        SYMBOL_STMT_LIST            = 69, // <stmt_list>
        SYMBOL_SWITCH_STMT          = 70, // <switch_stmt>
        SYMBOL_TERM                 = 71, // <term>
        SYMBOL_TERNARY_OPERATOR     = 72, // <ternary_operator>
        SYMBOL_VALUE                = 73, // <value>
        SYMBOL_VARIABLE_DECLARATION = 74, // <variable_declaration>
        SYMBOL_WHILE_STMT           = 75  // <while_stmt>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                   =  0, // <program> ::= Start <stmt_list> End
        RULE_STMT_LIST                                           =  1, // <stmt_list> ::= <concept> <stmt_list>
        RULE_STMT_LIST2                                          =  2, // <stmt_list> ::= <concept>
        RULE_CONCEPT                                             =  3, // <concept> ::= <variable_declaration>
        RULE_CONCEPT2                                            =  4, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                            =  5, // <concept> ::= <switch_stmt>
        RULE_CONCEPT4                                            =  6, // <concept> ::= <for_stmt>
        RULE_CONCEPT5                                            =  7, // <concept> ::= <while_stmt>
        RULE_CONCEPT6                                            =  8, // <concept> ::= <do_while>
        RULE_VARIABLE_DECLARATION_EQ                             =  9, // <variable_declaration> ::= <id> '=' <expr>
        RULE_VARIABLE_DECLARATION_EQ_STRING                      = 10, // <variable_declaration> ::= <id> '=' String
        RULE_VARIABLE_DECLARATION_EQ2                            = 11, // <variable_declaration> ::= <id> '=' <condition>
        RULE_VARIABLE_DECLARATION_EQ3                            = 12, // <variable_declaration> ::= <id> '=' <list>
        RULE_VARIABLE_DECLARATION_EQ4                            = 13, // <variable_declaration> ::= <id> '=' <ternary_operator>
        RULE_VARIABLE_DECLARATION_EQ5                            = 14, // <variable_declaration> ::= <id> '=' <dict>
        RULE_ID_IDENTIFIER                                       = 15, // <id> ::= Identifier
        RULE_EXPR_PLUS                                           = 16, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                          = 17, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                = 18, // <expr> ::= <term>
        RULE_TERM_TIMES                                          = 19, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                            = 20, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                        = 21, // <term> ::= <term> '%' <factor>
        RULE_TERM_GTGT                                           = 22, // <term> ::= <term> '>>' <factor>
        RULE_TERM_LTLT                                           = 23, // <term> ::= <term> '<<' <factor>
        RULE_TERM                                                = 24, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                   = 25, // <factor> ::= <factor> '**' <expo>
        RULE_FACTOR                                              = 26, // <factor> ::= <expo>
        RULE_EXPO_LPAREN_RPAREN                                  = 27, // <expo> ::= '(' <expo> ')'
        RULE_EXPO                                                = 28, // <expo> ::= <id>
        RULE_EXPO_DIGIT                                          = 29, // <expo> ::= Digit
        RULE_IF_STMT_IF_COLON_END                                = 30, // <if_stmt> ::= if <condition> ':' <stmt_list> End
        RULE_IF_STMT_IF_COLON_END2                               = 31, // <if_stmt> ::= if <condition> ':' <stmt_list> End <elif_stmt>
        RULE_ELIF_STMT_ELSE_IF_COLON_END                         = 32, // <elif_stmt> ::= else if <condition> ':' <stmt_list> End <elif_stmt>
        RULE_ELIF_STMT                                           = 33, // <elif_stmt> ::= <else_stmt>
        RULE_ELSE_STMT_ELSE_COLON_END                            = 34, // <else_stmt> ::= else ':' <stmt_list> End
        RULE_CONDITION_BITWISEOPERATOR                           = 35, // <condition> ::= <Expression> BitwiseOperator <condition>
        RULE_CONDITION                                           = 36, // <condition> ::= <Expression>
        RULE_EXPRESSION                                          = 37, // <Expression> ::= <expr> <op> <expr>
        RULE_EXPRESSION_BOOLEAN                                  = 38, // <Expression> ::= Boolean
        RULE_OP_GT                                               = 39, // <op> ::= '>'
        RULE_OP_LT                                               = 40, // <op> ::= '<'
        RULE_OP_GTEQ                                             = 41, // <op> ::= '>='
        RULE_OP_LTEQ                                             = 42, // <op> ::= '<='
        RULE_OP_EQEQ                                             = 43, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                         = 44, // <op> ::= '!='
        RULE_SWITCH_STMT_SWITCH_COLON_END                        = 45, // <switch_stmt> ::= switch <expr> ':' <case_list> End
        RULE_CASE_LIST_CASE_COLON_BREAK                          = 46, // <case_list> ::= case <expr> ':' <stmt_list> break <case_list>
        RULE_CASE_LIST_CASE_COLON_BREAK2                         = 47, // <case_list> ::= case <expr> ':' <stmt_list> break
        RULE_FOR_STMT_FOR_IN_RANGE_LPAREN_DIGIT_RPAREN_COLON_END = 48, // <for_stmt> ::= for <id> in range '(' Digit ')' ':' <stmt_list> End
        RULE_STEP_PLUSPLUS                                       = 49, // <step> ::= <id> '++'
        RULE_STEP_MINUSMINUS                                     = 50, // <step> ::= <id> '--'
        RULE_STEP_MINUSMINUS2                                    = 51, // <step> ::= '--' <id>
        RULE_STEP_PLUSPLUS2                                      = 52, // <step> ::= '++' <id>
        RULE_STEP_EQ                                             = 53, // <step> ::= <id> '=' <expr>
        RULE_WHILE_STMT_WHILE_COLON_END                          = 54, // <while_stmt> ::= while <condition> ':' <stmt_list> End
        RULE_DO_WHILE_DO_COLON_END_WHILE                         = 55, // <do_while> ::= do ':' <stmt_list> End while <condition>
        RULE_LIST_LIST_LPAREN_RPAREN                             = 56, // <list> ::= list '(' <inside_list> ')'
        RULE_LIST_LBRACKET_RBRACKET                              = 57, // <list> ::= '[' <inside_list> ']'
        RULE_INSIDE_LIST_DIGIT_COMMA                             = 58, // <inside_list> ::= Digit ',' <inside_list>
        RULE_INSIDE_LIST_STRING_COMMA                            = 59, // <inside_list> ::= String ',' <inside_list>
        RULE_INSIDE_LIST_DIGIT                                   = 60, // <inside_list> ::= Digit
        RULE_INSIDE_LIST_STRING                                  = 61, // <inside_list> ::= String
        RULE_TERNARY_OPERATOR_QUESTION_BOOLEAN_COLON_BOOLEAN     = 62, // <ternary_operator> ::= <expr> '?' Boolean ':' Boolean
        RULE_DICT_DICT_LPAREN_COLON_COMMA_RPAREN                 = 63, // <dict> ::= dict '(' <key> ':' <value> ',' <inside_dict> ')'
        RULE_DICT_LBRACE_RBRACE                                  = 64, // <dict> ::= '{' <inside_dict> '}'
        RULE_KEY                                                 = 65, // <key> ::= <id>
        RULE_VALUE_DIGIT                                         = 66, // <value> ::= Digit
        RULE_VALUE_STRING                                        = 67, // <value> ::= String
        RULE_VALUE_BOOLEAN                                       = 68, // <value> ::= Boolean
        RULE_VALUE                                               = 69, // <value> ::= <list>
        RULE_VALUE2                                              = 70, // <value> ::= <dict>
        RULE_INSIDE_DICT_COLON_COMMA                             = 71, // <inside_dict> ::= <key> ':' <value> ',' <inside_dict>
        RULE_INSIDE_DICT_COLON                                   = 72  // <inside_dict> ::= <key> ':' <value>
    };

    public class MyParser
    {
        private LALRParser parser;
        private ListBox errorListBox;
        private ListBox tokenListBox;
        public MyParser(string filename,ListBox errorListBox,ListBox tokenListBox)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.errorListBox = errorListBox;
            this.tokenListBox = tokenListBox;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += Parser_OnTokenRead;
        }

        private void Parser_OnTokenRead(LALRParser parser, TokenReadEventArgs args)
        {
            string message = "Token : " + args.Token.Text + " \t \t " + (SymbolConstants)args.Token.Symbol.Id;
            tokenListBox.Items.Add(message);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLT :
                //'<<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGT :
                //'>>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BITWISEOPERATOR :
                //BitwiseOperator
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //Boolean
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DICT :
                //dict
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LIST :
                //list
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANGE :
                //range
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_LIST :
                //<case_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DICT2 :
                //<dict>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE :
                //<do_while>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF_STMT :
                //<elif_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE_STMT :
                //<else_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPO :
                //<expo>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INSIDE_DICT :
                //<inside_dict>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INSIDE_LIST :
                //<inside_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEY :
                //<key>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LIST2 :
                //<list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STMT :
                //<switch_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERNARY_OPERATOR :
                //<ternary_operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE_DECLARATION :
                //<variable_declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT :
                //<while_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <variable_declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <switch_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <while_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <do_while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLARATION_EQ :
                //<variable_declaration> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLARATION_EQ_STRING :
                //<variable_declaration> ::= <id> '=' String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLARATION_EQ2 :
                //<variable_declaration> ::= <id> '=' <condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLARATION_EQ3 :
                //<variable_declaration> ::= <id> '=' <list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLARATION_EQ4 :
                //<variable_declaration> ::= <id> '=' <ternary_operator>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECLARATION_EQ5 :
                //<variable_declaration> ::= <id> '=' <dict>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_IDENTIFIER :
                //<id> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_GTGT :
                //<term> ::= <term> '>>' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_LTLT :
                //<term> ::= <term> '<<' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <expo>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <expo>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPO_LPAREN_RPAREN :
                //<expo> ::= '(' <expo> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPO :
                //<expo> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPO_DIGIT :
                //<expo> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_COLON_END :
                //<if_stmt> ::= if <condition> ':' <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_COLON_END2 :
                //<if_stmt> ::= if <condition> ':' <stmt_list> End <elif_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_STMT_ELSE_IF_COLON_END :
                //<elif_stmt> ::= else if <condition> ':' <stmt_list> End <elif_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELIF_STMT :
                //<elif_stmt> ::= <else_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSE_STMT_ELSE_COLON_END :
                //<else_stmt> ::= else ':' <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION_BITWISEOPERATOR :
                //<condition> ::= <Expression> BitwiseOperator <condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_BOOLEAN :
                //<Expression> ::= Boolean
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STMT_SWITCH_COLON_END :
                //<switch_stmt> ::= switch <expr> ':' <case_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST_CASE_COLON_BREAK :
                //<case_list> ::= case <expr> ':' <stmt_list> break <case_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST_CASE_COLON_BREAK2 :
                //<case_list> ::= case <expr> ':' <stmt_list> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_IN_RANGE_LPAREN_DIGIT_RPAREN_COLON_END :
                //<for_stmt> ::= for <id> in range '(' Digit ')' ':' <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_EQ :
                //<step> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_WHILE_COLON_END :
                //<while_stmt> ::= while <condition> ':' <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_DO_COLON_END_WHILE :
                //<do_while> ::= do ':' <stmt_list> End while <condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LIST_LIST_LPAREN_RPAREN :
                //<list> ::= list '(' <inside_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LIST_LBRACKET_RBRACKET :
                //<list> ::= '[' <inside_list> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSIDE_LIST_DIGIT_COMMA :
                //<inside_list> ::= Digit ',' <inside_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSIDE_LIST_STRING_COMMA :
                //<inside_list> ::= String ',' <inside_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSIDE_LIST_DIGIT :
                //<inside_list> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSIDE_LIST_STRING :
                //<inside_list> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERNARY_OPERATOR_QUESTION_BOOLEAN_COLON_BOOLEAN :
                //<ternary_operator> ::= <expr> '?' Boolean ':' Boolean
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DICT_DICT_LPAREN_COLON_COMMA_RPAREN :
                //<dict> ::= dict '(' <key> ':' <value> ',' <inside_dict> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DICT_LBRACE_RBRACE :
                //<dict> ::= '{' <inside_dict> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEY :
                //<key> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_DIGIT :
                //<value> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_STRING :
                //<value> ::= String
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_BOOLEAN :
                //<value> ::= Boolean
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<value> ::= <list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE2 :
                //<value> ::= <dict>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSIDE_DICT_COLON_COMMA :
                //<inside_dict> ::= <key> ':' <value> ',' <inside_dict>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSIDE_DICT_COLON :
                //<inside_dict> ::= <key> ':' <value>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'" + " In Line: " + args.UnexpectedToken.Location.LineNr;
            errorListBox.Items.Add(message);

            string expectedMessage = "Expected Token: " + args.ExpectedTokens.ToString();
            errorListBox.Items.Add(expectedMessage);
            //todo: Report message to UI?
        }

    }
}
