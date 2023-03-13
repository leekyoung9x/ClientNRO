// Decompiled with JetBrains decompiler
// Type: mFont
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 687436A1-78BC-4524-B90A-A496256C4770
// Assembly location: C:\Users\thtung\Downloads\client noah\Dragonboy_vn_v225_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

public class mFont
{
  public static int LEFT = 0;
  public static int RIGHT = 1;
  public static int CENTER = 2;
  public static int RED = 0;
  public static int YELLOW = 1;
  public static int GREEN = 2;
  public static int FATAL = 3;
  public static int MISS = 4;
  public static int ORANGE = 5;
  public static int ADDMONEY = 6;
  public static int MISS_ME = 7;
  public static int FATAL_ME = 8;
  public static int HP = 9;
  public static int MP = 10;
  private int space;
  private Image imgFont;
  private string strFont;
  private int[][] fImages;
  public static int yAddFont;
  public static int[] colorJava = new int[31]
  {
    0,
    16711680,
    6520319,
    16777215,
    16755200,
    5449989,
    21285,
    52224,
    7386228,
    16771788,
    0,
    (int) ushort.MaxValue,
    21285,
    16776960,
    5592405,
    16742263,
    33023,
    8701737,
    15723503,
    7999781,
    16768815,
    14961237,
    4124899,
    4671303,
    16096312,
    16711680,
    16755200,
    52224,
    16777215,
    6520319,
    16096312
  };
  public static mFont gI;
  public static mFont tahoma_7b_red;
  public static mFont tahoma_7b_blue;
  public static mFont tahoma_7b_white;
  public static mFont tahoma_7b_yellow;
  public static mFont tahoma_7b_yellowSmall;
  public static mFont tahoma_7b_dark;
  public static mFont tahoma_7b_green2;
  public static mFont tahoma_7b_green;
  public static mFont tahoma_7b_focus;
  public static mFont tahoma_7b_unfocus;
  public static mFont tahoma_7;
  public static mFont tahoma_7_blue1;
  public static mFont tahoma_7_blue1Small;
  public static mFont tahoma_7_green2;
  public static mFont tahoma_7_yellow;
  public static mFont tahoma_7_grey;
  public static mFont tahoma_7_red;
  public static mFont tahoma_7_blue;
  public static mFont tahoma_7_green;
  public static mFont tahoma_7_white;
  public static mFont tahoma_8b;
  public static mFont number_yellow;
  public static mFont number_red;
  public static mFont number_green;
  public static mFont number_gray;
  public static mFont number_orange;
  public static mFont bigNumber_red;
  public static mFont bigNumber_While;
  public static mFont bigNumber_yellow;
  public static mFont bigNumber_green;
  public static mFont bigNumber_orange;
  public static mFont bigNumber_blue;
  public static mFont bigNumber_black;
  public static mFont nameFontRed;
  public static mFont nameFontYellow;
  public static mFont nameFontGreen;
  public static mFont tahoma_7_greySmall;
  public static mFont tahoma_7b_yellowSmall2;
  public static mFont tahoma_7b_green2Small;
  public static mFont tahoma_7_whiteSmall;
  public static mFont tahoma_7b_greenSmall;
  public Font myFont;
  private int height;
  private int wO;
  public Color color1 = Color.white;
  public Color color2 = Color.gray;
  public sbyte id;
  public int fstyle;
  public string st1 = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴĐ";
  public string st2 = "¸µ¶·\u00B9¨\u00BE»\u00BC\u00BDÆ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô\u00ADøõö÷ùýúûüþ®¸µ¶·\u00B9¡\u00BE»\u00BC\u00BDÆ¢ÊÇÈÉËÐÌÎÏÑ£ÕÒÓÔÖÝ×ØÜÞãßáâä¤èåæçé¥íêëìîóïñòô¦øõö÷ùýúûüþ§";
  public const string str = " 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW";
  private int yAdd;
  private string pathImage;

  public mFont(string strFont, string pathImage, string pathData, int space)
  {
    try
    {
      this.strFont = strFont;
      this.space = space;
      this.pathImage = pathImage;
      DataInputStream dataInputStream = (DataInputStream) null;
      this.reloadImage();
      try
      {
        dataInputStream = MyStream.readFile(pathData);
        this.fImages = new int[(int) dataInputStream.readShort()][];
        for (int index = 0; index < this.fImages.Length; ++index)
        {
          this.fImages[index] = new int[4];
          this.fImages[index][0] = (int) dataInputStream.readShort();
          this.fImages[index][1] = (int) dataInputStream.readShort();
          this.fImages[index][2] = (int) dataInputStream.readShort();
          this.fImages[index][3] = (int) dataInputStream.readShort();
          this.setHeight(this.fImages[index][3]);
        }
        dataInputStream.close();
      }
      catch (Exception ex1)
      {
        try
        {
          dataInputStream.close();
        }
        catch (Exception ex2)
        {
          ex2.StackTrace.ToString();
        }
      }
    }
    catch (Exception ex)
    {
      ex.StackTrace.ToString();
    }
  }

  public mFont(sbyte id)
  {
    string str = "chelthm";
    if (id > (sbyte) 0 && id < (sbyte) 10 || id == (sbyte) 19)
    {
      this.yAdd = 1;
      str = "barmeneb";
    }
    else if (id >= (sbyte) 10 && id <= (sbyte) 18)
    {
      str = "chelthm";
      this.yAdd = 2;
    }
    else if (id > (sbyte) 24)
      str = "staccato";
    this.id = id;
    this.myFont = (Font) Resources.Load("FontSys/x" + (object) mGraphics.zoomLevel + "/" + str);
    if (id < (sbyte) 25)
    {
      this.color1 = this.setColorFont(id);
      this.color2 = this.setColorFont(id);
    }
    else
    {
      this.color1 = this.bigColor((int) id);
      this.color2 = this.bigColor((int) id);
    }
    this.wO = this.getWidthExactOf("o");
  }

  public static void init()
  {
    if (mGraphics.zoomLevel == 1)
    {
      mFont.tahoma_7b_red = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_red.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_blue = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_blue.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_white = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_white.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_yellow = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_yellow.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_yellowSmall = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_yellow.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_dark = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_brown.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_green2 = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_green2.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_green = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_green.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_focus = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_focus.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7b_unfocus = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7b_unfocus.png", "/myfont/tahoma_7b", 0);
      mFont.tahoma_7 = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_blue1 = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_blue1.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_green2 = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_green2.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_yellow = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_yellow.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_grey = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_grey.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_red = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_red.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_blue = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_blue.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_green = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_green.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_7_white = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_7_white.png", "/myfont/tahoma_7", 0);
      mFont.tahoma_8b = new mFont(" 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW", "/myfont/tahoma_8b.png", "/myfont/tahoma_8b", -1);
      mFont.number_yellow = new mFont(" 0123456789+-", "/myfont/number_yellow.png", "/myfont/number", 0);
      mFont.number_red = new mFont(" 0123456789+-", "/myfont/number_red.png", "/myfont/number", 0);
      mFont.number_green = new mFont(" 0123456789+-", "/myfont/number_green.png", "/myfont/number", 0);
      mFont.number_gray = new mFont(" 0123456789+-", "/myfont/number_gray.png", "/myfont/number", 0);
      mFont.number_orange = new mFont(" 0123456789+-", "/myfont/number_orange.png", "/myfont/number", 0);
      mFont.bigNumber_red = mFont.number_red;
      mFont.bigNumber_While = mFont.tahoma_7b_white;
      mFont.bigNumber_yellow = mFont.number_yellow;
      mFont.bigNumber_green = mFont.number_green;
      mFont.bigNumber_orange = mFont.number_orange;
      mFont.bigNumber_blue = mFont.tahoma_7_blue1;
      mFont.nameFontRed = mFont.tahoma_7_red;
      mFont.nameFontYellow = mFont.tahoma_7_yellow;
      mFont.nameFontGreen = mFont.tahoma_7_green;
      mFont.tahoma_7_greySmall = mFont.tahoma_7_grey;
      mFont.tahoma_7b_yellowSmall2 = mFont.tahoma_7_yellow;
      mFont.tahoma_7b_green2Small = mFont.tahoma_7b_green2;
      mFont.tahoma_7_whiteSmall = mFont.tahoma_7_white;
      mFont.tahoma_7b_greenSmall = mFont.tahoma_7b_green;
      mFont.tahoma_7_blue1Small = mFont.tahoma_7_blue1;
    }
    else
    {
      mFont.gI = new mFont((sbyte) 0);
      mFont.tahoma_7b_red = new mFont((sbyte) 1);
      mFont.tahoma_7b_blue = new mFont((sbyte) 2);
      mFont.tahoma_7b_white = new mFont((sbyte) 3);
      mFont.tahoma_7b_yellow = new mFont((sbyte) 4);
      mFont.tahoma_7b_yellowSmall = new mFont((sbyte) 4);
      mFont.tahoma_7b_dark = new mFont((sbyte) 5);
      mFont.tahoma_7b_green2 = new mFont((sbyte) 6);
      mFont.tahoma_7b_green = new mFont((sbyte) 7);
      mFont.tahoma_7b_focus = new mFont((sbyte) 8);
      mFont.tahoma_7b_unfocus = new mFont((sbyte) 9);
      mFont.tahoma_7 = new mFont((sbyte) 10);
      mFont.tahoma_7_blue1 = new mFont((sbyte) 11);
      mFont.tahoma_7_blue1Small = mFont.tahoma_7_blue1;
      mFont.tahoma_7_green2 = new mFont((sbyte) 12);
      mFont.tahoma_7_yellow = new mFont((sbyte) 13);
      mFont.tahoma_7_grey = new mFont((sbyte) 14);
      mFont.tahoma_7_red = new mFont((sbyte) 15);
      mFont.tahoma_7_blue = new mFont((sbyte) 16);
      mFont.tahoma_7_green = new mFont((sbyte) 17);
      mFont.tahoma_7_white = new mFont((sbyte) 18);
      mFont.tahoma_8b = new mFont((sbyte) 19);
      mFont.number_yellow = new mFont((sbyte) 20);
      mFont.number_red = new mFont((sbyte) 21);
      mFont.number_green = new mFont((sbyte) 22);
      mFont.number_gray = new mFont((sbyte) 23);
      mFont.number_orange = new mFont((sbyte) 24);
      mFont.bigNumber_red = new mFont((sbyte) 25);
      mFont.bigNumber_yellow = new mFont((sbyte) 26);
      mFont.bigNumber_green = new mFont((sbyte) 27);
      mFont.bigNumber_While = new mFont((sbyte) 28);
      mFont.bigNumber_blue = new mFont((sbyte) 29);
      mFont.bigNumber_orange = new mFont((sbyte) 30);
      mFont.bigNumber_black = new mFont((sbyte) 31);
      mFont.nameFontRed = mFont.tahoma_7b_red;
      mFont.nameFontYellow = mFont.tahoma_7_yellow;
      mFont.nameFontGreen = mFont.tahoma_7_green;
      mFont.tahoma_7_greySmall = mFont.tahoma_7_grey;
      mFont.tahoma_7b_yellowSmall2 = mFont.tahoma_7_yellow;
      mFont.tahoma_7b_green2Small = mFont.tahoma_7b_green2;
      mFont.tahoma_7_whiteSmall = mFont.tahoma_7_white;
      mFont.tahoma_7b_greenSmall = mFont.tahoma_7b_green;
      mFont.yAddFont = 1;
      if (mGraphics.zoomLevel != 1)
        return;
      mFont.yAddFont = -3;
    }
  }

  public void setHeight(int height) => this.height = height;

  public Color setColor(int rgb)
  {
    int num1 = rgb & (int) byte.MaxValue;
    int num2 = rgb >> 8 & (int) byte.MaxValue;
    int num3 = rgb >> 16 & (int) byte.MaxValue;
    float b = (float) num1 / 256f;
    float g = (float) num2 / 256f;
    return new Color((float) num3 / 256f, g, b);
  }

  public Color bigColor(int id) => new Color[7]
  {
    Color.red,
    Color.yellow,
    Color.green,
    Color.white,
    this.setColor(40404),
    Color.red,
    Color.black
  }[id - 25];

  public void setColorByID(int ID)
  {
    this.color1 = this.setColor(mFont.colorJava[ID]);
    this.color2 = this.setColor(mFont.colorJava[ID]);
  }

  public void setTypePaint(mGraphics g, string st, int x, int y, int align, sbyte idFont)
  {
    sbyte ID = this.id;
    if (idFont > (sbyte) 0)
      ID = idFont;
    --x;
    if (this.id > (sbyte) 24)
    {
      Color[] colorArray = new Color[6]
      {
        this.setColor(6029312),
        this.setColor(7169025),
        this.setColor(7680),
        this.setColor(0),
        this.setColor(9264),
        this.setColor(6029312)
      };
      this.color1 = colorArray[(int) this.id - 25];
      this.color2 = colorArray[(int) this.id - 25];
      this._drawString(g, st, x + 1, y, align);
      this._drawString(g, st, x - 1, y, align);
      this._drawString(g, st, x, y - 1, align);
      this._drawString(g, st, x, y + 1, align);
      this._drawString(g, st, x + 1, y + 1, align);
      this._drawString(g, st, x + 1, y - 1, align);
      this._drawString(g, st, x - 1, y - 1, align);
      this._drawString(g, st, x - 1, y + 1, align);
      this.color1 = this.bigColor((int) this.id);
      this.color2 = this.bigColor((int) this.id);
    }
    else
      this.setColorByID((int) ID);
    this._drawString(g, st, x, y - this.yAdd, align);
  }

  public Color setColorFont(sbyte id) => this.setColor(mFont.colorJava[(int) id]);

  public void drawString(mGraphics g, string st, int x, int y, int align)
  {
    if (mGraphics.zoomLevel == 1)
    {
      int length = st.Length;
      int x1;
      switch (align)
      {
        case 0:
          x1 = x;
          break;
        case 1:
          x1 = x - this.getWidth(st);
          break;
        default:
          x1 = x - (this.getWidth(st) >> 1);
          break;
      }
      for (int index1 = 0; index1 < length; ++index1)
      {
        int index2 = this.strFont.IndexOf(st[index1].ToString() + string.Empty);
        if (index2 == -1)
          index2 = 0;
        if (index2 > -1)
        {
          int x0 = this.fImages[index2][0];
          int y0 = this.fImages[index2][1];
          int w0 = this.fImages[index2][2];
          int h0 = this.fImages[index2][3];
          if (y0 + h0 > this.imgFont.texture.height)
          {
            y0 -= this.imgFont.texture.height;
            x0 = this.imgFont.texture.width / 2;
          }
          g.drawRegion(this.imgFont, x0, y0, w0, h0, 0, x1, y, 20);
        }
        x1 += this.fImages[index2][2] + this.space;
      }
    }
    else
      this.setTypePaint(g, st, x, y, align, (sbyte) 0);
  }

  public void drawStringBorder(mGraphics g, string st, int x, int y, int align)
  {
    if (mGraphics.zoomLevel == 1)
      this.drawString(g, st, x, y, align);
    else
      this.setTypePaint(g, st, x, y, align, (sbyte) 0);
  }

  public void drawStringBorder(mGraphics g, string st, int x, int y, int align, mFont font2)
  {
    if (mGraphics.zoomLevel == 1)
      this.drawString(g, st, x, y, align, font2);
    else
      this.drawStringBd(g, st, x, y, align, font2);
  }

  public void drawStringBd(mGraphics g, string st, int x, int y, int align, mFont font)
  {
    this.setTypePaint(g, st, x - 1, y - 1, align, (sbyte) 0);
    this.setTypePaint(g, st, x - 1, y + 1, align, (sbyte) 0);
    this.setTypePaint(g, st, x + 1, y - 1, align, (sbyte) 0);
    this.setTypePaint(g, st, x + 1, y + 1, align, (sbyte) 0);
    this.setTypePaint(g, st, x, y - 1, align, (sbyte) 0);
    this.setTypePaint(g, st, x, y + 1, align, (sbyte) 0);
    this.setTypePaint(g, st, x + 1, y, align, (sbyte) 0);
    this.setTypePaint(g, st, x - 1, y, align, (sbyte) 0);
    this.setTypePaint(g, st, x, y, align, (sbyte) 0);
  }

  public void drawString(mGraphics g, string st, int x, int y, int align, mFont font)
  {
    if (mGraphics.zoomLevel == 1)
    {
      int length = st.Length;
      int x1;
      switch (align)
      {
        case 0:
          x1 = x;
          break;
        case 1:
          x1 = x - this.getWidth(st);
          break;
        default:
          x1 = x - (this.getWidth(st) >> 1);
          break;
      }
      for (int index1 = 0; index1 < length; ++index1)
      {
        int index2 = this.strFont.IndexOf(st[index1]);
        if (index2 == -1)
          index2 = 0;
        if (index2 > -1)
        {
          int x0 = this.fImages[index2][0];
          int y0 = this.fImages[index2][1];
          int w0 = this.fImages[index2][2];
          int h0 = this.fImages[index2][3];
          if (y0 + h0 > this.imgFont.texture.height)
          {
            y0 -= this.imgFont.texture.height;
            x0 = this.imgFont.texture.width / 2;
          }
          if (!GameCanvas.lowGraphic && font != null)
          {
            g.drawRegion(font.imgFont, x0, y0, w0, h0, 0, x1 + 1, y, 20);
            g.drawRegion(font.imgFont, x0, y0, w0, h0, 0, x1, y + 1, 20);
          }
          g.drawRegion(this.imgFont, x0, y0, w0, h0, 0, x1, y, 20);
        }
        x1 += this.fImages[index2][2] + this.space;
      }
    }
    else
    {
      this.setTypePaint(g, st, x, y + 1, align, font.id);
      this.setTypePaint(g, st, x, y, align, (sbyte) 0);
    }
  }

  public MyVector splitFontVector(string src, int lineWidth)
  {
    MyVector myVector = new MyVector();
    string empty = string.Empty;
    for (int index = 0; index < src.Length; ++index)
    {
      if (src[index] == '\n' || src[index] == '\b')
      {
        myVector.addElement((object) empty);
        empty = string.Empty;
      }
      else
      {
        empty += (string) (object) src[index];
        if (this.getWidth(empty) > lineWidth)
        {
          int num = empty.Length - 1;
          while (num >= 0 && empty[num] != ' ')
            --num;
          if (num < 0)
            num = empty.Length - 1;
          myVector.addElement((object) empty.Substring(0, num));
          index = index - (empty.Length - num) + 1;
          empty = string.Empty;
        }
        if (index == src.Length - 1 && !empty.Trim().Equals(string.Empty))
          myVector.addElement((object) empty);
      }
    }
    return myVector;
  }

  public string splitFirst(string str)
  {
    string str1 = string.Empty;
    bool flag = false;
    for (int index = 0; index < str.Length; ++index)
    {
      if (!flag)
      {
        string strSource = str.Substring(index);
        str1 = !this.compare(strSource, " ") ? str1 + strSource : str1 + (object) str[index] + "-";
        flag = true;
      }
      else if (str[index] == ' ')
        flag = false;
    }
    return str1;
  }

  public string[] splitStrInLine(string src, int lineWidth)
  {
    ArrayList arrayList = this.splitStrInLineA(src, lineWidth);
    string[] strArray = new string[arrayList.Count];
    for (int index = 0; index < arrayList.Count; ++index)
      strArray[index] = (string) arrayList[index];
    return strArray;
  }

  public ArrayList splitStrInLineA(string src, int lineWidth)
  {
    ArrayList arrayList = new ArrayList();
    int num1 = 0;
    int index = 0;
    int length = src.Length;
    if (length < 5)
    {
      arrayList.Add((object) src);
      return arrayList;
    }
    string empty = string.Empty;
    try
    {
      while (true)
      {
        while (this.getWidthNotExactOf(empty) < lineWidth)
        {
          empty += (string) (object) src[index];
          ++index;
          if (src[index] != '\n')
          {
            if (index >= length - 1)
            {
              index = length - 1;
              break;
            }
          }
          else
            break;
        }
        if (index != length - 1 && src[index + 1] != ' ')
        {
          int num2 = index;
          while (src[index + 1] != '\n' && (src[index + 1] != ' ' || src[index] == ' ') && index != num1)
            --index;
          if (index == num1)
            index = num2;
        }
        string str = src.Substring(num1, index + 1 - num1);
        if (str[0] == '\n')
          str = str.Substring(1, str.Length - 1);
        if (str[str.Length - 1] == '\n')
          str = str.Substring(0, str.Length - 1);
        arrayList.Add((object) str);
        if (index != length - 1)
        {
          num1 = index + 1;
          while (num1 != length - 1 && src[num1] == ' ')
            ++num1;
          if (num1 != length - 1)
          {
            index = num1;
            empty = string.Empty;
          }
          else
            break;
        }
        else
          break;
      }
    }
    catch (Exception ex)
    {
      Cout.LogWarning("EXCEPTION WHEN REAL SPLIT " + src + "\nend=" + (object) index + "\n" + ex.Message + "\n" + ex.StackTrace);
      arrayList.Add((object) src);
    }
    return arrayList;
  }

  public string[] splitFontArray(string src, int lineWidth)
  {
    MyVector myVector = this.splitFontVector(src, lineWidth);
    string[] strArray = new string[myVector.size()];
    for (int index = 0; index < myVector.size(); ++index)
      strArray[index] = (string) myVector.elementAt(index);
    return strArray;
  }

  public bool compare(string strSource, string str)
  {
    for (int index = 0; index < strSource.Length; ++index)
    {
      if ((string.Empty + (object) strSource[index]).Equals(str))
        return true;
    }
    return false;
  }

  public int getWidth(string s)
  {
    if (mGraphics.zoomLevel != 1)
      return this.getWidthExactOf(s);
    int width = 0;
    for (int index1 = 0; index1 < s.Length; ++index1)
    {
      int index2 = this.strFont.IndexOf(s[index1]);
      if (index2 == -1)
        index2 = 0;
      width += this.fImages[index2][2] + this.space;
    }
    return width;
  }

  public int getWidthExactOf(string s)
  {
    try
    {
      return (int) new GUIStyle() { font = this.myFont }.CalcSize(new GUIContent(s)).x / mGraphics.zoomLevel;
    }
    catch (Exception ex)
    {
      Cout.LogError("GET WIDTH OF " + s + " FAIL.\n" + ex.Message + "\n" + ex.StackTrace);
      return this.getWidthNotExactOf(s);
    }
  }

  public int getWidthNotExactOf(string s) => s.Length * this.wO / mGraphics.zoomLevel;

  public int getHeight()
  {
    if (mGraphics.zoomLevel == 1)
      return this.height;
    if (this.height > 0)
      return this.height / mGraphics.zoomLevel;
    GUIStyle guiStyle = new GUIStyle();
    guiStyle.font = this.myFont;
    try
    {
      this.height = (int) guiStyle.CalcSize(new GUIContent("Adg")).y + 2;
    }
    catch (Exception ex)
    {
      Cout.LogError("FAIL GET HEIGHT " + ex.StackTrace);
      this.height = 20;
    }
    return this.height / mGraphics.zoomLevel;
  }

  public void _drawString(mGraphics g, string st, int x0, int y0, int align)
  {
    y0 += mFont.yAddFont;
    GUIStyle style = new GUIStyle(GUI.skin.label);
    style.font = this.myFont;
    float x = 0.0f;
    float y = 0.0f;
    switch (align)
    {
      case 0:
        x = (float) x0;
        y = (float) y0;
        style.alignment = TextAnchor.UpperLeft;
        break;
      case 1:
        x = (float) (x0 - GameCanvas.w);
        y = (float) y0;
        style.alignment = TextAnchor.UpperRight;
        break;
      case 2:
      case 3:
        x = (float) (x0 - GameCanvas.w / 2);
        y = (float) y0;
        style.alignment = TextAnchor.UpperCenter;
        break;
    }
    style.normal.textColor = this.color1;
    g.drawString(st, (int) x, (int) y, style);
  }

  public static string[] splitStringSv(string _text, string _searchStr)
  {
    int num1 = 0;
    int startIndex1 = 0;
    int length = _searchStr.Length;
    int num2 = _text.IndexOf(_searchStr, startIndex1);
    while (num2 != -1)
    {
      int startIndex2 = num2 + length;
      num2 = _text.IndexOf(_searchStr, startIndex2);
      ++num1;
    }
    string[] strArray = new string[num1 + 1];
    int num3 = _text.IndexOf(_searchStr);
    int startIndex3 = 0;
    int index = 0;
    while (num3 != -1)
    {
      strArray[index] = _text.Substring(startIndex3, num3 - startIndex3);
      startIndex3 = num3 + length;
      num3 = _text.IndexOf(_searchStr, startIndex3);
      ++index;
    }
    strArray[index] = _text.Substring(startIndex3, _text.Length - startIndex3);
    return strArray;
  }

  public void reloadImage()
  {
    if (mGraphics.zoomLevel != 1)
      return;
    this.imgFont = GameCanvas.loadImage(this.pathImage);
  }

  public void freeImage()
  {
  }
}
